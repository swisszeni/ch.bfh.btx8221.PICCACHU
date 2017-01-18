using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MenuViewModel MenuViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MenuViewModel>(); }
        }

        public override Task InitializeAsync(List<object> navigationData)
        {
            return Task.WhenAll(
                MenuViewModel.InitializeAsync(navigationData),
                NavigationService.NavigateToAsync<PICCOverviewViewModel>()
                );
        }
    }
}
