﻿using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using BFH_USZ_PICC.ViewModels;

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BasePage : ContentPage, INavigable
    {
        private BaseContentPage _content;

        public BasePage(Type contentElementType)
        {
            InitializeComponent();

            _content = (BaseContentPage)Activator.CreateInstance(contentElementType, this);

            FlyoutPositioningLayout.Children.Insert(0, _content);
            AbsoluteLayout.SetLayoutBounds(_content, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(_content, AbsoluteLayoutFlags.All);

            Title = _content.Title;

            string iconPath = "";
            if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
            {
                iconPath = "Assets\\emergency_icon.png";
            } else
            {
                iconPath = "emergency_icon.png";
            }

            ToolbarItem alert = new ToolbarItem("Notfall", iconPath, () => { EmergencyOverLay.IsVisible = !EmergencyOverLay.IsVisible; });
            ToolbarItems.Add(alert);
        }

        public ViewModelBase ContentBindingContext => (ViewModelBase)_content?.BindingContext;

        public Type GetContentType()
        {
            return _content?.GetType();
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

        public Task OnNavigatedToAsync(NavigationMode mode)
        {
            if (_content.BindingContext is INavigable)
            {
                return ((INavigable)_content.BindingContext).OnNavigatedToAsync(mode);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
