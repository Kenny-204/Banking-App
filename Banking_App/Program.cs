using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Bank.Models;
using Bank.Services;

namespace Bank
{

    public class BankApp

    {
        static bool doFilesExist = File.Exists("users.json");
        static string? json = doFilesExist ? File.ReadAllText("users.json") : null;
        static string? meta = doFilesExist ? File.ReadAllText("metadata.json") : null;
        internal static int _nextInt = File.Exists("metadata.json") ? JsonSerializer.Deserialize<int>(meta!) : 1;

        /// <summary>
        /// A dictionary to store all the created users/home/kenny/Desktop/Banking_App/Banking_App/Data
        /// </summary>
        public static Dictionary<string, User> Users = File.Exists("users.json") ?

        JsonSerializer.Deserialize<Dictionary<string, User>>(json!)!

        : new()
        {

        };
        /// <summary>
        /// Displays the user menu to enable the user to perform banking operations
        /// </summary>
        /// <param name="currentUser">The currently logged in user</param>
        public static void UserMenu(User currentUser)
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine($"---------------------------\nHello {currentUser.Name}. What would you like to do today?. \n(1.) Deposit \n(2.) Withdrawal \n(3.) Transfer \n(4.) Check Account Balance \n(5.) Logout");
                int option = int.Parse(ValidationServices.LoopTillValid("option", ValidationServices.IsValidNumber));
                switch (option)
                {
                    case 1:
                        bool deposited = false;
                        while (!deposited)
                        {
                        
                            int depositAmount = int.Parse(ValidationServices.LoopTillValid("amount to deposit", ValidationServices.IsValidNumber));
                            Console.WriteLine("Input Password");
                            string depositPassword = Console.ReadLine()!;
                            ValidationServices.validateLogin(depositPassword, "password", currentUser.AccountNumber);
                            currentUser.Deposit(depositAmount);
                            Console.WriteLine($"---------------------------\n{depositAmount} deposited successfully... your new balance is {currentUser.Balance}");
                            deposited = true;
                        }
                        break;
                    case 2:
                        bool withdrawn = false;
                        while (!withdrawn)
                        {
                            int withdrawAmount = int.Parse(ValidationServices.LoopTillValid("amount to withdraw", ValidationServices.IsValidNumber));
                            Console.WriteLine($"{withdrawAmount},{currentUser.Balance},{withdrawAmount < currentUser.Balance}");
                            while (withdrawAmount > currentUser.Balance)
                            {
                                Console.WriteLine("Withdraw amount cannot be greater than account balance");
                                withdrawAmount = int.Parse(ValidationServices.LoopTillValid("withdraw amount", ValidationServices.IsValidNumber));

                            }
                            Console.WriteLine("---------------------------\nInput your Password");
                            string withdrawalPassword = Console.ReadLine()!;
                            ValidationServices.validateLogin(withdrawalPassword, "password", currentUser.AccountNumber);
                            currentUser.Withdrawal(withdrawAmount);
                            Console.WriteLine($"---------------------------\n{withdrawAmount} withdrawn successfully... your new balance is {currentUser.Balance}");
                            withdrawn = true;
                        }

                        break;
                    case 3:
                        Console.WriteLine("Input recepient Account Number: ");

                        string accountNumber = Console.ReadLine()!;
                        accountNumber = ValidationServices.validateLogin(accountNumber, "accountNumber", null);
                        Console.WriteLine($"You are about to transfer to {Users[accountNumber].Name}");
                        Console.WriteLine("Input transfer amount : ");
                        int transferAmount = int.Parse(ValidationServices.LoopTillValid("transfer amount", ValidationServices.IsValidNumber));
                        while (transferAmount > currentUser.Balance)
                        {
                            Console.WriteLine("transfer amount cannot be greater than account balance");
                            transferAmount = int.Parse(ValidationServices.LoopTillValid("transfer amount", ValidationServices.IsValidNumber));

                        }
                        Console.WriteLine("Input Password");
                        string password = Console.ReadLine()!;
                        ValidationServices.validateLogin(password, "password", currentUser.AccountNumber);
                        currentUser.Transfer(transferAmount, accountNumber);
                        Console.WriteLine($"{transferAmount} has successfully been transfered to {accountNumber}");
                        FileService.SaveUsersToFile();
                        break;
                    case 4:
                        Console.WriteLine($"Dear {currentUser.Name} your current balance is {currentUser.Balance}");
                        break;
                    case 5:
                        showMenu = false;
                        break;

                }
            }
        }


        public static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine($"Welcome to your bank app (choose an option) \n(1.) Create new account \n(2.) Login \n(3.) Exit");

                int option = int.Parse(ValidationServices.LoopTillValid("option", ValidationServices.IsValidNumber));
                switch (option)
                {
                    case 1:
                        AuthenticationService.createAccount();
                        break;
                    case 2:
                        User? currentUser = AuthenticationService.Login();
                        UserMenu(currentUser!);
                        break;
                    case 3:
                        loop = false;
                        break;
                }
            }
        }
    }
}

