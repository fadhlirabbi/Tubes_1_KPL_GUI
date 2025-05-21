using System.Collections.Generic;

namespace API.Model
{
    public class ReminderConfig
    {
        public List<ReminderRule> ReminderRules { get; set; } = new();
    }
}
