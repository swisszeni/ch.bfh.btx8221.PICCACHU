using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BasePage : ContentPage
    {
        private BaseContentPage content;
        public BasePage(Type contentElementType, List<object> args = null)
        {
            InitializeComponent();

            // create args List if null
            args = args ?? new List<object>();

            // Always add this Page
            args.Insert(0, this);

            // convert to array
            object[] argsArray = args.ToArray();

            content = (BaseContentPage)Activator.CreateInstance(contentElementType, argsArray);

            FlyoutPositioningLayout.Children.Insert(0, content);
            AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.All);

            Title = content.Title;

            ToolbarItem alert = new ToolbarItem("Alarm", "icon.png", () => { EmergencyOverLay.IsVisible = !EmergencyOverLay.IsVisible; });
            ToolbarItems.Add(alert);
        }

        protected override void OnAppearing()
        {
            content.OnAppearing();
        }

    }
}
