using Contracts.Transaction;
using Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios.Operations;

public class PutMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly ICurrentUserService _currentUserService;

    public PutMoneyScenario(ITransactionService transactionService, ICurrentUserService currentUserService)
    {
        _transactionService = transactionService;
        _currentUserService = currentUserService;
    }

    public string Name => "Put money";

    public async Task Run()
    {
        double balanceChange = AnsiConsole.Ask<double>("How much money you want to put?");

        MoneyOperationResult result = await _transactionService.PutMoney(_currentUserService.User, balanceChange);

        string message = result switch
        {
            MoneyOperationResult.Success => "Successful transaction",
            MoneyOperationResult.InputError => "You entered negative value!",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("Print any button.");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}