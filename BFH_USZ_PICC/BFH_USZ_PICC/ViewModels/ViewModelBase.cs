using BFH_USZ_PICC.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase, INavigable
    {
        protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
        }

        #region navigation events

        public virtual Task InitializeAsync(List<object> navigationData)
        {
            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        public virtual Task OnNavigatedFromAsync()
        {
            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        public virtual Task OnNavigatedToAsync(NavigationMode mode)
        {
            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        #endregion

        #region popup functionality

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return Application.Current.MainPage?.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return Application.Current.MainPage?.DisplayAlert(title, message, accept, cancel);
        }

        #endregion
    }
}
