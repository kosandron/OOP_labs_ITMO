using Contracts.User;

namespace Presentation.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public LoginScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public Task<IScenario?> TryGetScenario()
    {
        if (_currentUser.User is not null)
        {
            return Task.FromResult<IScenario?>(null);
        }

        return Task.FromResult<IScenario?>(new LoginScenario(_userService));
    }
}