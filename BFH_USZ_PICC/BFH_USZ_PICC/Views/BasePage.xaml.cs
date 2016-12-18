using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BasePage : ContentPage, INavigable
    {
        private BaseContentPage content;
        private List<object> navigationArguments;
        public BasePage(Type contentElementType, List<object> args = null)
        {
            InitializeComponent();

            // save original args in var
            navigationArguments = args;

            // create copy of args List to modify
            args = args == null ? new List<object>() : new List<object>(args);

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

        #region Navigation Events

        protected override void OnAppearing()
        {
            base.OnDisappearing();
            content.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            content.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if(content.OnBackButtonPressed())
            {
                return true;
            } else
            {
                base.OnBackButtonPressed();
                return false;
            }
        }

        public Task OnNavigatedFromAsync()
        {
            if (content.BindingContext is INavigable)
            {
                return ((INavigable)content.BindingContext).OnNavigatedFromAsync();
            } else
            {
                return null;
            }
        }

        public Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (content.BindingContext is INavigable)
            {
                object navArgs = mode == NavigationMode.Forward ? navigationArguments : parameter;
                return ((INavigable)content.BindingContext).OnNavigatedToAsync(navArgs, mode);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
