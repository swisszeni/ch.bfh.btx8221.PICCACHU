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
using Xamarin.Forms;
using BFH_USZ_PICC.Interfaces;

[assembly: Dependency(typeof(BFH_USZ_PICC.Droid.DependencyServices.ReminderNotification_Droid))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class SecureStorage_Droid : ISecureStorage
    {
        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public byte[] Retrieve(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, byte[] dataBytes)
        {
            throw new NotImplementedException();
        }
    }
}