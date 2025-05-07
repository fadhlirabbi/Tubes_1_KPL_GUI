using System.Text.Json;

namespace Tubes_1_KPL.Model
{
    public class ReminderRule
    {
        public int DaysBefore { get; set; }
        public string Message { get; set; }
    }

    public class ReminderConfig
    {
        public List<ReminderRule> ReminderRules { get; set; }

        public static ReminderConfig LoadFromJson(string path)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string folderPath = Path.Combine(projectRoot, "JSON");
            string filePath = Path.Combine(folderPath, path);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[DEBUG] File konfigurasi tidak ditemukan: {filePath}");
                return new ReminderConfig { ReminderRules = [] };
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<ReminderConfig>(json);
        }
    }
}
