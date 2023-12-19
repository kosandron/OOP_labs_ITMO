using System.Text;
using Contracts.Transaction;
using Contracts.User;
using Models.Transactions;
using Spectre.Console;

namespace Presentation.Scenarios.UserData;

public class GetTransactionsHistoryScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly ICurrentUserService _currentUserService;

    public GetTransactionsHistoryScenario(ITransactionService transactionService, ICurrentUserService currentUserService)
    {
        _transactionService = transactionService;
        _currentUserService = currentUserService;
    }

    public string Name => "Get transactions history";

    public async Task Run()
    {
        ICollection<Transaction> transactions = await _transactionService.GetUserTransactions(_currentUserService.User);

        AnsiConsole.WriteLine("Number of transactions: " + transactions.Count);
        AnsiConsole.WriteLine("Time  Balance change");
        var stringBuilder = new StringBuilder();
        foreach (Transaction transaction in transactions)
        {
            stringBuilder.Append(transaction.Time);
            stringBuilder.Append(' ');
            stringBuilder.Append(transaction.BalanceChange);
            stringBuilder.Append('\n');
        }

        AnsiConsole.WriteLine(stringBuilder.ToString());

        AnsiConsole.WriteLine("Print any button.");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}