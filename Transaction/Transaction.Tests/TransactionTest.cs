using Transaction;

namespace Transaction.Tests;

public class TransactionTest
{
    TotalTransactionAmount TransactionAmount { get; set; }
    
    [SetUp]
    public void Precondition()
    {
        TransactionAmount = new TotalTransactionAmount();
    }

    [Test]
    [TestCase(9)]
    [TestCase(1_000_001)]
    public void Calculate_WhenOutOfBoundsTransactionAmount_ThrowsArgumentOutOfRangeException(decimal transactionAmount)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => TransactionAmount.Calculate(transactionAmount));
    }
    
    [Test]
    [TestCase(10, 11)]
    [TestCase(100, 110)]
    [TestCase(999, 1098.9)]
    public void Calculate_WhenTransactionAmountLessThan1000_TenPercentCommission(decimal amount, decimal expectedResult)
    {
        var actualResult = TransactionAmount.Calculate(amount);
        
        Assert.AreEqual(expectedResult, actualResult);
    }
    
    [Test]
    [TestCase(1000, 1050)]
    [TestCase(5000, 5250)]
    [TestCase(9999, 10498.95)]
    public void Calculate_WhenTransactionAmountBetween1000And9999_FivePercentCommission(decimal amount, decimal expectedResult)
    {
        var actualResult = TransactionAmount.Calculate(amount);
        
        Assert.AreEqual(expectedResult, actualResult);
    }
    
    [Test]
    [TestCase(10_000, 10_100)]
    [TestCase(100_000, 101_000)]
    [TestCase(1_000_000, 1_010_000)]
    public void Calculate_WhenTransactionAmountIsGreaterOrEqualTo10000_OnePercentCommission(decimal amount, decimal expectedResult)
    {
        var actualResult = TransactionAmount.Calculate(amount);
        
        Assert.AreEqual(expectedResult, actualResult);
    }
}