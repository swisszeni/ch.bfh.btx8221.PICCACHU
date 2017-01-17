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
        #region public properties

        private string _switchContextButtonString;
        public string SwitchContextButtonString
        {
            get
            {
                return "TEST";
            }
        }

        private DisplayingKnowledgePage _displayingSubPage;
        public DisplayingKnowledgePage DisplayingSubPage
        {
            get { return _displayingSubPage; }
            set
            {
                Set(ref _displayingSubPage);
            }
        }

        #endregion

        #region relay commands

        private RelayCommand _switchContextCommand;
        public RelayCommand SwitchContextCommand => _switchContextCommand ?? (_switchContextCommand = new RelayCommand(() =>
        {
            // We want to display one subpage and display the other
            DisplayingSubPage = DisplayingSubPage == DisplayingKnowledgePage.Glossary ? DisplayingKnowledgePage.KnowledgeEntries : DisplayingKnowledgePage.Glossary:
        }));

        #endregion
    }
}
