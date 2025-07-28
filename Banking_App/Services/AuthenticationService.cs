
using Bank.Models;
using Bank.utils;

namespace Bank.Services

{

    public static class AuthenticationService
    {
        /// <summary>
        /// collects and validates user input to create a new bank account and stores the user to the Users dictionary
        /// </summary>
        public static void createAccount()
        {
            bool confirm = false;


            string name = "";
            string email = "";
            string gender = "";
            string password = "";
            int nextInt = BankApp._nextInt;
            string accountNumber = "AC00" + nextInt;

            while (confirm == false)
            {
                Console.WriteLine("---------------------------");
                name = ValidationServices.LoopTillValid("name", ValidationServices.IsInputNotEmpty, "name cannot be empty");
                email = ValidationServices.LoopTillValid("email", ValidationServices.IsEmailValid, "email needs to contain '@' and '.com' ");
                gender = ValidationServices.LoopTillValid("gender", ValidationServices.IsGenderValid, "Gender can only be male or female");

                password = ValidationServices.validateField(password, "password");

                Console.WriteLine("---------------------------");
                Console.WriteLine($"Confirm your details \nName: {name} \nEmail: {email} \nGender: {gender} \n(1.) Yes \n(2.) No ");
                int option = int.Parse(ValidationServices.LoopTillValid("option", ValidationServices.IsValidNumber));

                confirm = option == 1;

            }
            BankApp.Users.Add(accountNumber, new User(name, email, gender.ToLower(), accountNumber, PasswordHelper.hashPassword(password)));
            BankApp._nextInt++;
            FileService.SaveUsersToFile();
            FileService.SaveMetaData();
            Console.WriteLine("");
            Console.WriteLine($"---------------------------\nCongratulations... you have successfully created a new account \nYour account number is {accountNumber}\n---------------------------");

        }



        /// <summary>
        /// Collects and validates user input to log a user into the bank app
        /// </summary>
        /// <returns>The logged in user or null</returns>
        public static User? Login()
        {
            User? user = null;
            bool login = false;
            while (login == false)
            {

                string accountNumber = "";
                string password = "";

                Console.WriteLine("---------------------------\nLogin to your account");
                accountNumber = ValidationServices.LoopTillValid("Account Number", ValidationServices.IsAccountNumberValid);
                Console.WriteLine(accountNumber);
                if (accountNumber == "exit")
                {
                    return null;
                }
                Console.WriteLine("---------------------------\nInput your Password");
                password = Console.ReadLine()!;
                password = ValidationServices.validateLogin(password, "password", accountNumber);
                BankApp.Users.TryGetValue(accountNumber, out user);
                Console.WriteLine($"---------------------------\nLogin Successful. Hello {user!.Name}");
                login = true;
            }
            return user;
        }

    }
}