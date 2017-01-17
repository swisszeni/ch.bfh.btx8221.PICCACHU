using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Set Menu to always show on Desktop
            MasterBehavior = (Device.Idiom != TargetIdiom.Phone) ? MasterBehavior.Split : MasterBehavior.Popover;
            UpdateChildrenLayout();
        }
    }
}
