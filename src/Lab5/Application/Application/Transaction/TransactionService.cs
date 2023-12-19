using Abstractions.Repositories;
using Contracts.Transaction;

namespace Application.Transaction;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUserRepository _userRepository;

    public TransactionService(ITransactionRepository transactionRepository, IUserRepository userRepository)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
    }

    public async Task<MoneyOperationResult> PutMoney(Models.Users.User? user, double deltaMoney)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (deltaMoney <= 0)
        {
            return MoneyOperationResult.InputError;
        }

        await _transactionRepository.CreateTransaction(user, deltaMoney);
        return MoneyOperationResult.Success;
    }

    public async Task<MoneyOperationResult> TakeMoney(Models.Users.User? user, double deltaMoney)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (deltaMoney <= 0)
        {
            return MoneyOperationResult.InputError;
        }

        double balance = await _userRepository.GetUserBalance(user);
        if (balance - deltaMoney < 0)
        {
            return MoneyOperationResult.Fail;
        }

        await _transactionRepository.CreateTransaction(user, -deltaMoney);
        return MoneyOperationResult.Success;
    }

    public async Task<ICollection<Models.Transactions.Transaction>> GetUserTransactions(Models.Users.User? user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        return await _transactionRepository.GetUserTransactions(user);
    }
}