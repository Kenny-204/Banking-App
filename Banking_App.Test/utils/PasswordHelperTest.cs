using Bank.utils;

namespace Banking_App.Test.utils;

public class UnitTest1
{
    [Fact]
    public void hashPassword_Input_InputNotEqualToHash()
    {
        var result = PasswordHelper.hashPassword("input");
        Assert.NotEqual("input", result);
    }


}