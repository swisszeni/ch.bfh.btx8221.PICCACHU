using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            ToolbarItem alert = new ToolbarItem("Alarm", "icon.png", async () => { });
            ToolbarItems.Add(alert);
        }
    }
}
