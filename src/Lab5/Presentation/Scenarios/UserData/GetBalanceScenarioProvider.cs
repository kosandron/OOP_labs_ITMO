using Contracts.User;

namespace Presentation.Scenarios.UserData;

public class GetBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public GetBalanceScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUserService = currentUser;
    }

    public Task<IScenario?> TryGetScenario()
    {
        if (_currentUserService.User is null)
        {
            return Task.FromResult<IScenario?>(null);
        }

        return Task.FromResult<IScenario?>(new GetBalanceScenario(_userService, _currentUserService));
    }
}