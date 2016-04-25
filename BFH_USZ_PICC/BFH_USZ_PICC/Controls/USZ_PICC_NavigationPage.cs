using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Controls
{
    class USZ_PICC_NavigationPage : NavigationPage
    {
        public USZ_PICC_NavigationPage(Page root) : base(root)
        {
            Init();
        }

        public USZ_PICC_NavigationPage()
        {
            Init();
        }

        private void Init()
        {
            BarBackgroundColor = Color.FromHex("#0057A2");
            BarTextColor = Color.White;
        }
    }
}
