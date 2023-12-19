using Contracts.Login;
using Models.Users;

namespace Contracts.User;

public interface IUserService
{
    Task<LoginResult> Login(int login, string password);
    void Logout();
    Task<Models.Users.User?> GetUser(int login, string password);
    Task<Models.Users.User?> CreateUser(string password, UserStatus status);
    Task<double> GetUserBalance(Models.Users.User? user);
}