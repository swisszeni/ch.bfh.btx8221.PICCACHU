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

using BFH_USZ_PICC.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(BFH_USZ_PICC.Droid.DependencyServices.FileHelper_Droid))]
namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class FileHelper_Droid : IFileHelper
    {
        public string GetLocalUserdataDatabaseFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }

        public string GetLocalAppdataDatabaseFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}