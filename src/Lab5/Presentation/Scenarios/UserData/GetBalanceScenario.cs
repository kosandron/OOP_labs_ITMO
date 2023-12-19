using Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios.UserData;

public class GetBalanceScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public GetBalanceScenario(IUserService userService, ICurrentUserService currentUserService)
    {
        _userService = userService;
        _currentUserService = currentUserService;
    }

    public string Name => "Get balance";

    public async Task Run()
    {
         double balance = await _userService.GetUserBalance(_currentUserService.User);
         AnsiConsole.WriteLine("Your balance is " + balance);

         AnsiConsole.WriteLine("Print any button.");
         AnsiConsole.Console.Input.ReadKey(false);
    }
}