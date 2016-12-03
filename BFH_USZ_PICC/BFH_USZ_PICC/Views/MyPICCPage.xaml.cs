using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MyPICCPage : BaseContentPage
    {

        public MyPICCPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        }
    }
}
