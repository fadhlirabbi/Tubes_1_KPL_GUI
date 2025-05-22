
using System.Text.Json;

namespace API.Model
{
    public class ReminderConfig
    {
        public List<ReminderRule> Rules { get; set; } = new List<ReminderRule>();

        private readonly string _filePath;

        public ReminderConfig()
        {
            string root = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "API", "Data");
            _filePath = Path.Combine(root, "reminder.json");
        }

        public void LoadConfig()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var loadedConfig = JsonSerializer.Deserialize<ReminderConfig>(json);

                if (loadedConfig != null)
                    Rules = loadedConfig.Rules ?? new List<ReminderRule>();
            }
            else
            {
                Console.WriteLine("Reminder config file not found. Using default rules.");
            }
        }
    }
}
