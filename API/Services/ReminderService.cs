using API.Model;
using System.Text.Json;

namespace API.Services
{
    public static class ReminderService
    {
        public static ReminderConfig LoadFromJson(string fileName)
        {
            // Ambil path root ke dalam folder /Data/
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
            string dataFolder = Path.Combine(projectRoot, "API", "Data");
            string filePath = Path.Combine(dataFolder, fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[DEBUG] File tidak ditemukan: {filePath}");
                return new ReminderConfig { ReminderRules = new List<ReminderRule>() };
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<ReminderConfig>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
