using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class GlossaryPage : BaseContentPage
    {
        public GlossaryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            Title = "Glossar";

            //Binds all glossary entries to the binding context
            
        }

        //This method checks whitch glossary entry has been selected and displays the related information in a pop up.
        void SelectedEntry(object sender, EventArgs e)
        {
            GlossaryList.SelectedItem = null;
        }
    }
}
