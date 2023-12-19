using Core.Entities;
using Npgsql;

namespace DataBaseConnector.Service;

public class DataBaseWriter : IDataBaseWriter
{
    private readonly string connectionString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
    private NpgsqlDataSource dataSource;
    public DataBaseWriter()
    {
        await CreateDataSource();
    }

    private async Task CreateDataSource()
    {
        await using var dataSource = NpgsqlDataSource.Create(connectionString);
    }

    public async Task CreateUser(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using NpgsqlCommand command = connection.CreateCommand();

        command.CommandText = """
                              INSERT INTO Users (id, login, password, adminStatus)
                              VALUES ()
                              """;
        
        
    }

    public async Task CreateTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}