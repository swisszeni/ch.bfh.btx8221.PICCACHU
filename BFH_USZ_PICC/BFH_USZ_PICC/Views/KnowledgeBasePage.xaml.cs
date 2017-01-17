using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;


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
            _glossary.IsVisible = false;
            Children.Add(_glossary);

            _knowledge = new KnowledgeEntriesPage(contained);
            Grid.SetRow(_knowledge, 1);
            Children.Add(_knowledge);
        }
    }
}
