using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.UWP.DependencyServices;
using Xamarin.Forms;
using Windows.ApplicationModel.Calls;


[assembly: Dependency(typeof(Caller))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    public class Caller : ICaller
    {
        public bool Dial(string number)
        {
            //PhoneCallManager phoneCallManager = new PhoneCallManager
            //{
            //    PhoneNumber = number,
            //    DisplayName = "Phoneword"
            //};

            //phoneCallTask.Show();
             return true;
        }
    }
}
