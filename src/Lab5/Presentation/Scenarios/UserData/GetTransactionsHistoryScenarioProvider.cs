using Contracts.Transaction;
using Contracts.User;

namespace Presentation.Scenarios.UserData;

public class GetTransactionsHistoryScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly ICurrentUserService _currentUserService;

    public GetTransactionsHistoryScenarioProvider(
        ITransactionService transactionService,
        ICurrentUserService currentUser)
    {
        _transactionService = transactionService;
        _currentUserService = currentUser;
    }

    public Task<IScenario?> TryGetScenario()
    {
        if (_currentUserService.User is null)
        {
            return Task.FromResult<IScenario?>(null);
        }

        return Task.FromResult<IScenario?>(new GetTransactionsHistoryScenario(_transactionService, _currentUserService));
    }
}