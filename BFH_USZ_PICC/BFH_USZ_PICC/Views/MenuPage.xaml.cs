using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MenuPage : ContentPage
    {
        Shell appShell;
        List<NavigationMenuItem> menuItems;

        public MenuPage(Shell appShell)
        {
            this.appShell = appShell;

            InitializeComponent();

            BindingContext = new BaseViewModel
            {
                Title = "Menu",
                Subtitle = "Menu",
                Icon = "icon.png"
            };

            ListViewMenu.ItemsSource = menuItems = new List<NavigationMenuItem>
                {
                    new NavigationMenuItem { Title = "PICC", MenuItemKey = MenuItemKey.PICC, Icon ="icon.png" },
                    new NavigationMenuItem { Title = "Glossar", MenuItemKey = MenuItemKey.Glossary, Icon = "icon.png" },
                    new NavigationMenuItem { Title = "Wissenswertes", MenuItemKey = MenuItemKey.Knowledge, Icon = "icon.png" },
                    new NavigationMenuItem { Title = "Störungen", MenuItemKey = MenuItemKey.Disorder, Icon = "icon.png" }
                };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await this.appShell.NavigateAsync(((NavigationMenuItem)e.SelectedItem).MenuItemKey);
            };
        }
    }
}
