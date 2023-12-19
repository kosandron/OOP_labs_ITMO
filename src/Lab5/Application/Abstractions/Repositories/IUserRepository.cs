using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> GetUser(int id, string password);
    Task<User?> CreateUser(string password, UserStatus status);
    Task<double> GetUserBalance(User? user);
}