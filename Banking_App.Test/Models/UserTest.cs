using Bank;
using Bank.Models;

namespace Banking_App.Test.Models;

public class UnitTest1
{
    [Fact]
    public void Deposit_AddsAmountToBalance()
    {
        var user = new User("kenny", "mail@mail.com", "male", "AC001", "pass");

        user.Deposit(100);

        Assert.Equal(100, user.Balance);
    }
    [Fact]
    public void Withdraw_ReducesAmountFromBalance()
    {
        var user = new User("kenny", "mail@mail.com", "male", "AC001", "pass");

        user.Withdrawal(100);

        Assert.Equal(-100, user.Balance);
    }
    [Fact]
    public void Transfer_ReducesAmountFromBalanceAddToRecepient()
    {
        var user = new User("kenny", "mail@mail.com", "male", "AC001", "pass");
        BankApp.Users["AC002"] = new User("kenny2", "mail@mail.com", "male", "AC002", "pass");

        user.Transfer(100, "AC002");

        Assert.Equal(-100, user.Balance);
        Assert.Equal(100, BankApp.Users["AC002"].Balance);
    }
}