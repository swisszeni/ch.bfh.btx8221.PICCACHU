using BFH_USZ_PICC.Interfaces;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(BFH_USZ_PICC.UWP.DependencyServices.FileHelper_UWP))]
namespace BFH_USZ_PICC.UWP.DependencyServices
{
    public class FileHelper_UWP : IFileHelper
    {
        public string GetLocalUserdataDatabaseFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }

        public string GetLocalAppdataDatabaseFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
