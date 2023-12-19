namespace Models.Transactions;

public record Transaction(int UserId, DateTime Time, double BalanceChange);
