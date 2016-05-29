using BFH_USZ_PICC.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public class BaseContentPage : Grid
    {
        public string Title { get; set; }
        public ContentPage ContainedPage { get; private set; }
        //public NavigationEventArgs Navigation { get; private set; }

        public BaseContentPage(ContentPage contained)
        {
            ContainedPage = contained;
            //Nav
            //display
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return ContainedPage.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return ContainedPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
