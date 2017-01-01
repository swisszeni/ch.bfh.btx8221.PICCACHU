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

        public virtual Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }
    }
}
