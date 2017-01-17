using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public enum DisplayingKnowledgePage
    {
        KnowledgeEntries,
        Glossary
    }

    public class KnowledgeBaseViewModel : ViewModelBase
    {
        public KnowledgeBaseViewModel() { }

        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            DisplayingSubPage = DisplayingKnowledgePage.KnowledgeEntries;
            SwitchContextButtonString = AppResources.GlossaryPageTitleText;

            RaisePropertyChanged("");

            return base.InitializeAsync(navigationData);
        }

        #endregion

        #region public properties

        private string _switchContextButtonString;
        public string SwitchContextButtonString
        {
            get { return _switchContextButtonString; }
            set { Set(ref _switchContextButtonString, value); }
        }

        private DisplayingKnowledgePage _displayingSubPage;
        public DisplayingKnowledgePage DisplayingSubPage
        {
            get { return _displayingSubPage; }
            set { Set(ref _displayingSubPage, value); }
        }

        #endregion

        #region relay commands

        private RelayCommand _switchContextCommand;
        public RelayCommand SwitchContextCommand => _switchContextCommand ?? (_switchContextCommand = new RelayCommand(() =>
        {
            // We want to display one subpage and display the other
            if (DisplayingSubPage == DisplayingKnowledgePage.Glossary)
            {
                DisplayingSubPage = DisplayingKnowledgePage.KnowledgeEntries;
                SwitchContextButtonString = AppResources.GlossaryPageTitleText;
            } else
            {
                DisplayingSubPage = DisplayingKnowledgePage.Glossary;
                SwitchContextButtonString = AppResources.KnowledgeEntriesTitleText;
            }
        }));

        #endregion

    }
}
