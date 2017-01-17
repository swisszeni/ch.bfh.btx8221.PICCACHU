using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using BFH_USZ_PICC.ViewModels;

namespace BFH_USZ_PICC.Views
{
    public partial class KnowledgeBasePage : BaseContentPage
    {
        private KnowledgeEntriesPage _knowledge;
        private GlossaryPage _glossary;
        public KnowledgeBasePage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            _glossary = new GlossaryPage(contained);
            Grid.SetRow(_glossary, 1);
            Children.Add(_glossary);

            _knowledge = new KnowledgeEntriesPage(contained);
            Grid.SetRow(_knowledge, 1);
            Children.Add(_knowledge);

            var vm = BindingContext as KnowledgeBaseViewModel;
            if (vm != null)
            {
                vm.PropertyChanged += DisplayingContextChanged;
            }
        }

        private void DisplayingContextChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(KnowledgeBaseViewModel.DisplayingSubPage))
            {
                // DisplayingSubPage is updated, adjust Visibility
                // TODO: FIX TITLE
                var vm = BindingContext as KnowledgeBaseViewModel;
                if (vm.DisplayingSubPage == DisplayingKnowledgePage.KnowledgeEntries)
                {
                    _knowledge.IsVisible = true;
                    _glossary.IsVisible = false;
                } else
                {
                    _knowledge.IsVisible = false;
                    _glossary.IsVisible = true;
                }
            }
        }
    }
}
