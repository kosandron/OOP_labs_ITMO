using Contracts.User;

namespace Application.User;

public class CurrentUserManager : ICurrentUserService
{
    public Models.Users.User? User { get; private set; }

    public void Login(Models.Users.User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        User = user;
    }

    public void Logout()
    {
        User = null;
    }
}