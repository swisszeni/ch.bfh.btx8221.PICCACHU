using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class FormerPICCDetailPage : BaseContentPage
    {
        /// <summary>
        /// Default constructor
        /// 
        /// author: Florian Schnyder
        /// </summary>
        /// <param name="contained">BasePage</param>
        public FormerPICCDetailPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        } 
    }
}
