using Models.Transactions;
using Models.Users;

namespace Abstractions.Repositories;

public interface ITransactionRepository
{
    Task CreateTransaction(User user, double deltaMoney);
    Task<ICollection<Transaction>> GetUserTransactions(User user);
}