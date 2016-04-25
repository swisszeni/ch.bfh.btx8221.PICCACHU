using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC
{
    public class Shell : MasterDetailPage
    {
        Dictionary<MenuItemKey, NavigationPage> Pages { get; set; }

        public Shell()
        {

        }

    }
}
