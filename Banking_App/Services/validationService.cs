using Bank.utils;


namespace Bank.Services
{
    public static class ValidationServices
    {
        /// <summary>
        /// check if the input is empty
        /// </summary>
        /// <param name="input">the input</param>
        /// <returns>true if the input is empty and false if its nor</returns>
        public static bool IsInputNotEmpty(string input) => !string.IsNullOrWhiteSpace(input);
        /// <summary>
        /// checks if the account number exists
        /// </summary>
        /// <param name="input">the input account number</param>
        /// <returns>True if exists and false if it doesnt</returns>
        public static bool IsAccountNumberValid(string input) => BankApp.Users.ContainsKey(input);
        public static bool IsEmailValid(string input) => input.Contains('@') && input.Contains(".com");
        public static bool IsGenderValid(string input) => input.Equals("male", StringComparison.CurrentCultureIgnoreCase) || input.Equals("female", StringComparison.CurrentCultureIgnoreCase);
        public static bool IsValidNumber(string input) => int.TryParse(input, out var result) && !(int.Parse(input) < 0);
        /// <summary>
        /// Keeps asking the user for input while the input is invalid
        /// </summary>
        /// <param name="fieldName">The type of input</param>
        /// <param name="isValid">A function which validates the input</param>
        /// <param name="errorMessage">an optional error message</param>
        /// <returns>a valid input</returns>

        public static string LoopTillValid(string fieldName, Func<string, bool> isValid, string? errorMessage = null)
        {
            string input;
            do
            {
                Console.WriteLine($"Input your {fieldName}: ");
                input = Console.ReadLine()!;
                if (!isValid(input))
                {
                    Console.WriteLine(errorMessage ?? $"{fieldName} is invalid. Try Again. ");
                }

            } while (!isValid(input));
            return input;
        }
        /// <summary>
        /// Validates login input fields, such as account number and password
        /// </summary>
        /// <param name="field">The input field to be validated</param>
        /// <param name="fieldName">The type of the input</param>
        /// <param name="currentAccountNumber">The account number to be validated against</param>
        /// <returns>A validated input string</returns>
        public static string validateLogin(string field, string fieldName, string? currentAccountNumber)
        {
            string validString = field;
            bool valid = false;
            while (valid == false)
            {
                if (string.IsNullOrWhiteSpace(validString))
                {
                    Console.WriteLine($"{fieldName} is invalid... try again");
                    validString = Console.ReadLine()!;
                }
                else
                {
                    valid = true;
                }
            }
            if (fieldName == "password")
            {
                bool validPassword = false;
                while (!validPassword)
                {

                    BankApp.Users.TryGetValue(currentAccountNumber!, out var user);
                    if (!user!.Password.Equals(PasswordHelper.hashPassword(validString)))
                    {
                        Console.WriteLine("Incorrect Password");
                        validString = Console.ReadLine()!;
                    }
                    else if (validString.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return "exit";
                    }
                    else
                    {
                        validPassword = true;
                    }

                }
            }

            return validString;
        }

        /// <summary>
        /// validates signup fields.
        /// </summary>
        /// <param name="field">Input field to be validated</param>
        /// <param name="fieldName">Type of input field</param>
        /// <returns>A valid input field</returns>

        public static string validateField(string field, string fieldName)
        {
            string validString = field;

            if (fieldName == "password")
            {
                string password = field;
                bool confirmPassword = false;

                while (confirmPassword == false)
                {
                    Console.WriteLine($"Input your password: ");
                    password = Console.ReadLine()!;
                    Console.WriteLine($"Confirm your password: ");
                    string passwordConfirm = Console.ReadLine()!;
                    confirmPassword = passwordConfirm == password;
                    if (confirmPassword == false)
                    {
                        Console.WriteLine("---------------------------\nPasswords do not match\n---------------------------");

                    }
                    else { return password; }
                }
            }
            // else 
            return validString;
        }

    }
}