﻿using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class DisorderDetailPage : BaseContentPage
    {
        public DisorderDetailPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        }
    }
}
