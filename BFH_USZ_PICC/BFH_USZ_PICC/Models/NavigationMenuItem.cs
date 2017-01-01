using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum MenuItemKey
    {
        PICC,
        Knowledge, 
        Disorder,
        Journal, 
        Settings
    }
    public class NavigationMenuItem
    {
        public int Id { get; set; }
        public MenuItemKey MenuItemKey { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public NavigationMenuItem()
        {
            MenuItemKey = MenuItemKey.PICC;
        }
    }
}
