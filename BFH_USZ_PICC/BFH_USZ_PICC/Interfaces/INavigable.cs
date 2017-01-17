using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public enum NavigationMode
    {
        Back = 0,
        Forward = 1
    }

    public interface INavigable
    {
        Task OnNavigatedFromAsync();
        Task OnNavigatedToAsync(NavigationMode mode);
    }
}
