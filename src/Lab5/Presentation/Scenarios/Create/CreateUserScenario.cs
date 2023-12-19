using Contracts.User;
using Models.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Create;

public class CreateUserScenario : IScenario
{
    private readonly IUserService _userService;

    public CreateUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Create user";

    public async Task Run()
    {
        string password = AnsiConsole.Ask<string>("Enter password:");
        UserStatus status = AnsiConsole.Ask<UserStatus>("Enter status of new user:");
        User? user = await _userService.CreateUser(password, status);

        if (user is null)
        {
            AnsiConsole.WriteLine("Creation error!");
            return;
        }

        AnsiConsole.WriteLine("Id: " + user.Id);
        AnsiConsole.WriteLine("User status: " + user.Status);
        AnsiConsole.WriteLine("Print any button.");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}