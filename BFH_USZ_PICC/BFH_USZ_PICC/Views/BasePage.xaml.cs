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
        private BaseContentPage _content;
        private List<object> _navigationArguments;

        public BasePage(Type contentElementType, List<object> args = null)
        {
            InitializeComponent();

            // save original args in var
            _navigationArguments = args;

            // create copy of args List to modify
            args = args == null ? new List<object>() : new List<object>(args);

            // Always add this Page
            args.Insert(0, this);

            // convert to array
            object[] argsArray = args.ToArray();

            _content = (BaseContentPage)Activator.CreateInstance(contentElementType, argsArray);

            FlyoutPositioningLayout.Children.Insert(0, _content);
            AbsoluteLayout.SetLayoutBounds(_content, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(_content, AbsoluteLayoutFlags.All);

            Title = _content.Title;

            ToolbarItem alert = new ToolbarItem("Alarm", "icon.png", () => { EmergencyOverLay.IsVisible = !EmergencyOverLay.IsVisible; });
            ToolbarItems.Add(alert);
        }

        #region Navigation Events

        protected override void OnAppearing()
        {
            base.OnDisappearing();
            _content.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            // Always remove the flyout
            EmergencyOverLay.IsVisible = false;
            base.OnDisappearing();
            _content.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if(_content.OnBackButtonPressed())
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
            if (_content.BindingContext is INavigable)
            {
                return ((INavigable)_content.BindingContext).OnNavigatedFromAsync();
            } else
            {
                return null;
            }
        }

        public Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (_content.BindingContext is INavigable)
            {
                object navArgs = mode == NavigationMode.Forward ? _navigationArguments : parameter;
                return ((INavigable)_content.BindingContext).OnNavigatedToAsync(navArgs, mode);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
