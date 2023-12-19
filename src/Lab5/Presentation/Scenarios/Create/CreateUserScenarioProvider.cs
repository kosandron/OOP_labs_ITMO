using Contracts.User;
using Models.Users;

// using Models.Users;
namespace Presentation.Scenarios.Create;

public class CreateUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public CreateUserScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public Task<IScenario?> TryGetScenario()
    {
         if (_currentUser.User is null || _currentUser.User.Status != UserStatus.Admin)
        {
            return Task.FromResult<IScenario?>(null);
        }

         return Task.FromResult<IScenario?>(new CreateUserScenario(_userService));
    }
}