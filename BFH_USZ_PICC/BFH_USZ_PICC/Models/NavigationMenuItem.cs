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
        Glossary,
        Disorder,
        Journal, 
        Settings
    }
    public class NavigationMenuItem
    {
        public MenuItemKey MenuItemKey { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
