using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BFH_USZ_PICC.Droid.DependencyServices;

namespace BFH_USZ_PICC.Droid
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var resultIntent = new Intent(context, typeof(MainActivity));
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);

            var pending = PendingIntent.GetActivity(context, 0,
                resultIntent,
                PendingIntentFlags.CancelCurrent);

            var builder =
                new Notification.Builder(context)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetSmallIcon(Resource.Drawable.ic_launcher)
                    .SetDefaults(NotificationDefaults.All)
                    .SetAutoCancel(true);
                     

            builder.SetContentIntent(pending);

            var notification = builder.Build();

            var manager = NotificationManager.FromContext(context);
            manager.Notify(1337, notification);
        }
        
    }
}