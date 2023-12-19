using Contracts.Transaction;
using Contracts.User;

namespace Presentation.Scenarios.Operations;

public class PutMoneyScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly ICurrentUserService _currentUserService;

    public PutMoneyScenarioProvider(
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

        return Task.FromResult<IScenario?>(new PutMoneyScenario(_transactionService, _currentUserService));
    }
}