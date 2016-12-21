using BFH_USZ_PICC.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(BFH_USZ_PICC.iOS.DependencyServices.FileHelper_iOS))]
namespace BFH_USZ_PICC.iOS.DependencyServices
{
    public class FileHelper_iOS : IFileHelper
    {
        public string GetLocalUserdataDatabaseFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

        public string GetLocalAppdataDatabaseFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
