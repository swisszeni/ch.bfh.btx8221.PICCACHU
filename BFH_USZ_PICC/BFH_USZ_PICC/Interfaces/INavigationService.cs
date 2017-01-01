using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(List<object> navParams) where TViewModel : ViewModelBase;
        Task NavigateToAsync(MenuItemKey pageKey);
        Task NavigateToAsync(MenuItemKey pageKey, List<object> navParams);

        Task DeepNavigateToAsync(Type deepViewModelType, MenuItemKey basePageKey);
        Task DeepNavigateToAsync<TViewModel>(MenuItemKey basePageKey) where TViewModel : ViewModelBase;
        Task DeepNavigateToAsync(Type deepViewModelType, MenuItemKey basePageKey, List<object> deepPagenavParams);
        Task DeepNavigateToAsync<TViewModel>(MenuItemKey basePageKey, List<object> deepPagenavParams) where TViewModel : ViewModelBase;

        Task NavigateBackAsync();
        Task RemoveLastFromBackStackAsync();
    }
}
