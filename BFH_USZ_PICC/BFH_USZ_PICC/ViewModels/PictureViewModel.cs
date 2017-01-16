using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    public class PictureViewModel : ViewModelBase
    {
        private KnowledgeEntryImageElement _displayingImage;

        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            if (navigationData is List<object> && ((List<object>)navigationData).Count > 0)
            {
                _displayingImage = (KnowledgeEntryImageElement)((List<object>)navigationData).First();

                RaisePropertyChanged("");
            }

            return base.InitializeAsync(navigationData);
        }

        #endregion

        #region public properties

        public ImageSource ImageSource => ((Image)_displayingImage?.element)?.Source;
        public bool HasImageCaption => !String.IsNullOrEmpty(_displayingImage?.Caption);
        public string ImageCaption => _displayingImage?.Caption;

        #endregion

        #region relay commands

        private RelayCommand _hidePictureDetailCommand;
        public RelayCommand HidePictureDetailCommand => _hidePictureDetailCommand ?? (_hidePictureDetailCommand = new RelayCommand(() =>
        {
            // Image tapped, hide detailview
            NavigationService.NavigateBackAsync();
        }));

        #endregion

    }
}
