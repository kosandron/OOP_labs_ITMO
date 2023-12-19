namespace Contracts.User;

public interface ICurrentUserService
{
    Models.Users.User? User { get;  }
    public void Login(Models.Users.User user);
    public void Logout();
}