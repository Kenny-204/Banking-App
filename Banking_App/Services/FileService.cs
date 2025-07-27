using System.Text.Json;

namespace Bank.Services
{
    public static class FileService
    {
        /// <summary>
        /// Stores the number of accounts created in a file
        /// </summary>
        public static void SaveMetaData()
        {
            var json = JsonSerializer.Serialize(BankApp._nextInt);
            File.WriteAllText("metadata.json", json);
        }

        /// <summary>
        /// Saves the Users dictionary to a file "users.json"
        /// </summary>
        public static void SaveUsersToFile()
        {
            var json = JsonSerializer.Serialize(BankApp.Users);
            File.WriteAllText("users.json", json);
        }


    }
}