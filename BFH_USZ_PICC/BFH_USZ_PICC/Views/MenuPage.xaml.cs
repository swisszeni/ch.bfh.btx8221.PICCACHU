using BFH_USZ_PICC.Models;
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

            this.InitializeComponent();
        }
    }
}
