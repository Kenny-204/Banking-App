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
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            var fullPath = Path.Combine(projectRoot, "data", "metadata.json");
            var json = JsonSerializer.Serialize(BankApp._nextInt);
            File.WriteAllText(fullPath, json);
        }

        /// <summary>
        /// Saves the Users dictionary to a file "users.json"
        /// </summary>
        public static void SaveUsersToFile()
        {
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            var fullPath = Path.Combine(projectRoot, "data", "user.json");
            var json = JsonSerializer.Serialize(BankApp.Users);
            File.WriteAllText(fullPath, json);
        }


    }
}