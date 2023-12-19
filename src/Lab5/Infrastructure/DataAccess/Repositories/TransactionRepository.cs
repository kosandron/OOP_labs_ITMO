using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Transactions;
using Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task CreateTransaction(User user, double deltaMoney)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        NpgsqlCommand command = connection.CreateCommand();
        command.CommandText = """
                              INSERT INTO Transactions (Id, Time, BalanceChange)
                              VALUES (@id, @time, @balanceChange);
                              UPDATE Users SET Balance = @balanceChange + Balance WHERE Id = @id;
                              """;
        command.Parameters.AddWithValue("id", user.Id);
        command.Parameters.AddWithValue("time", DateTime.UtcNow);
        command.Parameters.AddWithValue("balanceChange", deltaMoney);

        await using NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();
    }

    public async Task<ICollection<Transaction>> GetUserTransactions(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        NpgsqlCommand command = connection.CreateCommand();
        command.CommandText = """
                              SELECT Id, Time, BalanceChange
                              FROM Transactions
                              WHERE Id = @login;
                              """;
        command.Parameters.AddWithValue("login", user.Id);

        await using NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();

        ICollection<Transaction> transactions = new List<Transaction>();
        while (await dataReader.ReadAsync())
        {
            DateTime time = dataReader.GetDateTime(1);
            double balanceDifference = dataReader.GetDouble(2);
            transactions.Add(new Transaction(user.Id, time, balanceDifference));
        }

        return transactions;
    }
}