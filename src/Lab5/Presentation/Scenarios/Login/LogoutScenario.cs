using Contracts.User;

namespace Presentation.Scenarios.Login;

public class LogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";

    public Task Run()
    {
        _userService.Logout();
        return Task.CompletedTask;
    }
}