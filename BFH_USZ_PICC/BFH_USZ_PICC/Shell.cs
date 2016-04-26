using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using BFH_USZ_PICC.Views;
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
            Pages = new Dictionary<MenuItemKey, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
            {
                Title = "USZ PICC",
                Icon = "icon.png"
            };
            //setup home page
            NavigateAsync(MenuItemKey.PICC);

            InvalidateMeasure();
        }

        public async Task NavigateAsync(MenuItemKey id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {
                    case MenuItemKey.PICC:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new GlossaryPage()));
                        break;
                    case MenuItemKey.Glossary:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new GlossaryPage()));
                        break;
                    case MenuItemKey.Knowledge:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new KnowledgeEntrysPage()));
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            //if (IsUWPDesktop)
            //    return;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }

    }
}
