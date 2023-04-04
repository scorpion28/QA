namespace Transaction;

public class TotalTransactionAmount
{
    private const decimal MinAmount = 10m;
    private const decimal MaxAmount = 1_000_000m;

    public decimal Calculate(decimal transactionAmount)
    {
        if (transactionAmount < MinAmount || transactionAmount > MaxAmount)
            throw new ArgumentOutOfRangeException(
                nameof(transactionAmount), $"Transaction amount must be between {MinAmount} and {MaxAmount}");

        var fee = transactionAmount switch
        {
            < 1_000 => 10,
            < 10_000 => 5,
            >= 10_000 => 1
        };

        return transactionAmount + transactionAmount * fee / 100;
    }
}