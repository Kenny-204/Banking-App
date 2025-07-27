using Bank;
namespace Bank.Models
{

    /// <summary>
    /// Represents a bank user with personal details, account number and balance. Supports deposit, withdrawal and transfer operations
    /// </summary>
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public User(string name, string email, string gender, string accountNumber, string password)
        {
            Name = name;
            Email = email;
            Gender = gender;
            AccountNumber = accountNumber;
            Password = password;
            Balance = 0;
        }
        // public string GetPassword()
        // {
        //     return Password;
        // }
        // public int GetBalance() => _balance;
        // public string GetName() => _name;
        // public string GetAccountNumber() => _accountNumber;

        public void Deposit(int amount)
        {
            Balance += amount;
        }
        public void Withdrawal(int amount)
        {
            Balance -= amount;
        }

        public void Transfer(int amount, string recipient)
        {
            Balance -= amount;
            BankApp.Users[recipient].Balance += amount;
        }
    }

}
