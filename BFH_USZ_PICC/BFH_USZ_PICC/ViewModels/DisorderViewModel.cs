using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    class DisorderViewModel : ViewModelBase
    {
        #region public properties

        /// <summary>
        /// Adds a list with all "Disorder" objects to the "ListOfDisorderEntries" variable.
        /// </summary>
        private List<DisorderEntry> _disorderEntriesList =  DisorderEntries.getEntries();
        public List<DisorderEntry> DisorderEntriesList
        {
            get { return _disorderEntriesList; }
            set
            {
                Set(ref _disorderEntriesList, value);
            }
        }

        #endregion

        #region relay commands

        private RelayCommand<DisorderEntry> _itemSelectedCommand;
        public RelayCommand<DisorderEntry> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<DisorderEntry>((DisorderEntry selectedItem) =>
        {
            // Item selected, handle navigation
            // TODO: FIX
            // ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(DisorderDetailPage), new List<object> { value }));
        }));

        #endregion
    }
}
