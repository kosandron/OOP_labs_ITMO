using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> GetUser(int id, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return null;
        }

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        NpgsqlCommand command = connection.CreateCommand();
        command.CommandText = """
                              SELECT Id, Password, AdminStatus
                              FROM Users
                              WHERE Id = @id AND Password = @password
                              """;
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("password", password);

        await using NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();
        if (!await dataReader.ReadAsync())
        {
            return null;
        }

        return new User(
            dataReader.GetInt32(0),
            dataReader.GetString(1),
            dataReader.GetBoolean(2) ? UserStatus.Admin : UserStatus.User);
    }

    public async Task<User?> CreateUser(string password, UserStatus status)
    {
        if (string.IsNullOrEmpty(password))
        {
            return null;
        }

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        NpgsqlCommand command = connection.CreateCommand();
        command.CommandText = """
                              INSERT INTO Users(Password, AdminStatus, Balance)
                              VALUES (@password, @status, 0)
                              RETURNING Id;
                              """;
        command.Parameters.AddWithValue("password", password);
        command.Parameters.AddWithValue("status", status == UserStatus.Admin);

        await using NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();
        if (!await dataReader.ReadAsync())
        {
            return null;
        }

        return new User(dataReader.GetInt32(0), password, status);
    }

    public async Task<double> GetUserBalance(User? user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        NpgsqlCommand command = connection.CreateCommand();
        command.CommandText = """
                              SELECT Balance
                              FROM Users
                              WHERE Id = @id
                              """;
        command.Parameters.AddWithValue("id", user.Id);

        await using NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();
        if (!await dataReader.ReadAsync())
        {
            throw new ArgumentException("User was not found!");
        }

        return dataReader.GetDouble(0);
    }
}