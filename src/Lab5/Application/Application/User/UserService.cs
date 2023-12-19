using Abstractions.Repositories;
using Contracts.Login;
using Contracts.User;
using Models.Users;

namespace Application.User;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ICurrentUserService _currentUserManager;

    public UserService(IUserRepository repository, ICurrentUserService currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<LoginResult> Login(int login, string password)
    {
        Models.Users.User? user = await _repository.GetUser(login, password);

        if (user is null)
        {
            return LoginResult.Fail;
        }

        _currentUserManager.Login(user);
        return LoginResult.Success;
    }

    public void Logout()
    {
        _currentUserManager.Logout();
    }

    public Task<Models.Users.User?> GetUser(int login, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException(nameof(password));
        }

        return _repository.GetUser(login, password);
    }

    public Task<Models.Users.User?> CreateUser(string password, UserStatus status)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException(nameof(password));
        }

        return _repository.CreateUser(password, status);
    }

    public Task<double> GetUserBalance(Models.Users.User? user)
    {
        return _repository.GetUserBalance(user);
    }
}