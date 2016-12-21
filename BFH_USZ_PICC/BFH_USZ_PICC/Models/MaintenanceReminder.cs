using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{

    //This class contains the needed information for the maintenance reminder
    public class MaintenanceReminder
    {
        public DateTimeOffset ReminderStartDate { get; set; }
        public TimeSpan ReminderDayTime { get; set; }
        public int ReminderFrequency { get; set; }
        public int ReminderRepetition { get; set; }
        public bool IsReminderSet { get; set; }

        private static MaintenanceReminder _maintenanceReminder;

        private MaintenanceReminder() { }

        public static MaintenanceReminder Reminder
        {
            get { return _maintenanceReminder == null ? new MaintenanceReminder() : _maintenanceReminder; }
        }

        public static void DeleteMaintainanceReminder()
        {
            _maintenanceReminder = null;
        }
    }
}

