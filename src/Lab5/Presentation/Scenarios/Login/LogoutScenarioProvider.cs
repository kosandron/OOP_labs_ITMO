using Contracts.User;

namespace Presentation.Scenarios.Login;

public class LogoutScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public LogoutScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public Task<IScenario?> TryGetScenario()
    {
        if (_currentUser.User is null)
        {
            return Task.FromResult<IScenario?>(null);
        }

        return Task.FromResult<IScenario?>(new LogoutScenario(_userService));
    }
}