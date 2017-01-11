using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Controls
{
    public class USZ_PICC_NavigationPage : NavigationPage
    {
        private Page prevPage;
        public USZ_PICC_NavigationPage(Page root) : base(root)
        {
            prevPage = root;
            Init();
            if (root as INavigable != null)
            {
                ((INavigable)root).OnNavigatedToAsync(NavigationMode.Forward);
            }
        }

        public USZ_PICC_NavigationPage()
        {
            Init();
        }

        private void Init()
        {
            BarBackgroundColor = Color.FromHex("#0057A2");
            BarTextColor = Color.White;
            Pushed += Content_Pushed;
            Popped += Content_Popped;
            PoppedToRoot += Content_PoppedToRoot;
        }

        #region Navigation methods

        private void Content_Pushed(object sender, NavigationEventArgs e)
        {
            INavigable curr = null;
            if (CurrentPage is INavigable)
            {
                curr = (INavigable)CurrentPage;
            }
            prevPage = CurrentPage;
            curr?.OnNavigatedToAsync(null, NavigationMode.Forward);
        }

        private void Content_Popped(object sender, NavigationEventArgs e)
        {
            INavigable prev = null;
            INavigable curr = null;
            if (prevPage is INavigable)
            {
                prev = (INavigable)prevPage;
            }

            if (CurrentPage is INavigable)
            {
                curr = (INavigable)CurrentPage;
            }

            prevPage = CurrentPage;
            prev?.OnNavigatedFromAsync();
            curr?.OnNavigatedToAsync(NavigationMode.Back);
        }

        private void Content_PoppedToRoot(object sender, NavigationEventArgs e)
        {
            INavigable prev = null;
            INavigable curr = null;
            if (prevPage is INavigable)
            {
                prev = (INavigable)prevPage;
            }

            if (CurrentPage is INavigable)
            {
                curr = (INavigable)CurrentPage;
            }

            prevPage = CurrentPage;
            curr?.OnNavigatedToAsync(NavigationMode.Forward);
        }

        #endregion
    }
}
