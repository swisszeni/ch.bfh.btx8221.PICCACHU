using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class MaintenanceInstructionPage : BaseContentPage
    {
        public MaintenanceInstructionPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            // TODO: Fix title problem
            // Title = instruction.Title;
        }
    }
}
