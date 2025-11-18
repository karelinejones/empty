namespace AtmServices.Test;

using AtmServices;

public class AtmTests

{

    Atm testAtm;

    int initialBalance = 100;

    public AtmTests() {

        testAtm = new Atm(initialBalance);

    }

 

    [Fact]

    public void Test_Withdraw()

    {

        var result = testAtm.withdraw(25);

        Assert.True(result);

        Assert.Equal(75, testAtm.getBalance());

    }

    [Fact]

    public void Test_Withdraw_InsufficientFunds()

    {

        var result = testAtm.withdraw(150);

        Assert.False(result);

        Assert.Equal(100, testAtm.getBalance());

    }

    

    [Fact]

    public void Test_Withdraw_ExactBalance()

    {

        var result = testAtm.withdraw(100);

        Assert.False(result);

        Assert.Equal(100, testAtm.getBalance());

    }

    

    [Fact]

    public void Test_Deposit_PositiveAmount()

    {

        var result = testAtm.deposit(50);

        Assert.True(result);

        Assert.Equal(150, testAtm.getBalance());

    }

    

    [Fact]

    public void Test_Deposit_ZeroAmount()

    {

        var result = testAtm.deposit(0);

        Assert.True(result);

        Assert.Equal(100, testAtm.getBalance());

    }

    

    [Fact]

    public void Test_Deposit_NegativeAmount()

    {

        var result = testAtm.deposit(-25);

        Assert.False(result);

        Assert.Equal(100, testAtm.getBalance());

    }

    

    [Fact]

    public void Test_GetBalance_Initial()

    {

        Assert.Equal(100, testAtm.getBalance());

    }

    

    [Fact]

    public void Test_Constructor_WithDifferentBalance()

    {

        var newAtm = new Atm(250);

        Assert.Equal(250, newAtm.getBalance());

    }

    

    [Fact]

    public void Test_MultipleOperations()

    {

        testAtm.deposit(50);

        Assert.Equal(150, testAtm.getBalance());

        

        testAtm.withdraw(30);

        Assert.Equal(120, testAtm.getBalance());

        

        var failedWithdraw = testAtm.withdraw(150);

        Assert.False(failedWithdraw);

        Assert.Equal(120, testAtm.getBalance());
    }

}

 