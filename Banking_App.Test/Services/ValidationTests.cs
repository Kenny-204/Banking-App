using Bank;
using Bank.Models;
using Bank.Services;


namespace Banking_App.Test.Services;

public class UnitTest1
{
    [Fact]
    public void IsEmailValid_ValidEmail_ReturnTrue()
    {
        // Arrange
        string validEmail = "mail@mail.com";
        // Act
        bool result = ValidationServices.IsEmailValid(validEmail);
        // Assert
        Assert.True(result);
    }
    [Fact]
    public void IsEmailValid_EmailWithoutAtSymbol_ReturnFalse()
    {
        // Arrange
        string validEmail = "mail.com";
        // Act
        bool result = ValidationServices.IsEmailValid(validEmail);
        // Assert
        Assert.False(result);
    }
    [Fact]
    public void IsEmailValid_EmailWithout_ReturnFalse()
    {
        // Arrange
        string validEmail = "mail@mail";
        // Act
        bool result = ValidationServices.IsEmailValid(validEmail);
        // Assert
        Assert.False(result);
    }
    [Fact]
    public void IsEmailValid_EmptyEmail_ReturnFalse()
    {
        // Arrange
        string validEmail = "";
        // Act
        bool result = ValidationServices.IsEmailValid(validEmail);
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsGenderValid_Inputmale_ReturnTrue()
    {
        Assert.True(ValidationServices.IsGenderValid("male"));
    }
    [Fact]
    public void IsGenderValid_InputMALE_ReturnTrue()
    {
        Assert.True(ValidationServices.IsGenderValid("MALE"));
    }
    [Fact]
    public void IsGenderValid_InputInvalidGender_ReturnFalse()
    {
        Assert.False(ValidationServices.IsGenderValid("Robot"));
    }
    [Fact]
    public void IsGenderValid_InputEmpty_ReturnFalse()
    {
        Assert.False(ValidationServices.IsGenderValid(""));
    }
    [Fact]
    public void IsAccountNumberValid_InputExistingUser_ReturnTrue()
    {
        BankApp.Users["AC001"] = new User("kenny", "mail@mail.com", "male", "AC001", "pass");
        Assert.True(ValidationServices.IsAccountNumberValid("AC001"));
    }
    [Fact]
    public void IsAccountNumberValid_InputNonExistingUser_ReturnFalse()
    {
        Assert.False(ValidationServices.IsAccountNumberValid("AC007"));
    }
    [Fact]
    public void IsAccountNumberValid_InputEmpty_ReturnFalse()
    {
        Assert.False(ValidationServices.IsAccountNumberValid(""));
    }

}