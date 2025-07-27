using System.Security.Cryptography;
using System.Text;

namespace Bank.utils
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Hashes the given plain text password using SHA256 algorithm to protect it from being stored in plain text
        /// </summary>
        /// <param name="input">The password in plain text</param>
        /// <returns>The hashed password</returns>
        public static string hashPassword(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

    }
}