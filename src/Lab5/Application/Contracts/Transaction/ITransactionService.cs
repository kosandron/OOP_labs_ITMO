namespace Contracts.Transaction;

public interface ITransactionService
{
    Task<MoneyOperationResult> PutMoney(Models.Users.User? user, double deltaMoney);
    Task<MoneyOperationResult> TakeMoney(Models.Users.User? user, double deltaMoney);
    Task<ICollection<Models.Transactions.Transaction>> GetUserTransactions(Models.Users.User? user);
}