using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Utilitys;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public partial class MainPage_iOS : TabbedPage
    {
        public MainPage_iOS()
        {
            InitializeComponent();
            // 
        }

        public void AddRootPage(NavigationMenuItem menuItem, USZ_PICC_NavigationPage rootPage)
        {
            rootPage.Title = menuItem.Title;
            var iconConverter = new MenuItemKeyToIconConverter();
            rootPage.Icon = (string)iconConverter.Convert(menuItem.MenuItemKey, typeof(string), null, null);

            Children.Add(rootPage);
        }
    }
}
