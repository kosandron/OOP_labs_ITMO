using Contracts.Login;
using Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public async Task Run()
    {
        int login = AnsiConsole.Ask<int>("Enter your login number");
        string password = AnsiConsole.Ask<string>("Enter your password");
        LoginResult result = await _userService.Login(login, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.Fail => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);

        AnsiConsole.WriteLine("Print any button.");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}