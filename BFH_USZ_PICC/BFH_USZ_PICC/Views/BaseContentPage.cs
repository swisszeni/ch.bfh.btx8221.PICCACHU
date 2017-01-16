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

        public BaseContentPage(ContentPage contained)
        {
            ContainedPage = contained;
        }

        #region Navigation Events

        public virtual void OnAppearing()
        {

        }

        public virtual void OnDisappearing()
        {

        }

        public virtual bool OnBackButtonPressed()
        {
            return false;
        }

        #endregion
    }
}
