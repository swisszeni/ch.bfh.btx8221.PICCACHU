using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface IReminderNotification
    {
        /// <summary>
        /// Add a new notification for a certain amount of time.
        /// </summary>
        /// <returns></returns>
        void AddNotification(DateTimeOffset maintenanceReminderStartDateAndTime, int dailyInterval, int maintenanceReminderRepetition, string notificationTitle, string notificatonMessage, bool isUnlimited);

        /// <summary>
        /// Removes all planned notifications in the future
        /// </summary>
        void RemoveAllNotifications();
    }
}
