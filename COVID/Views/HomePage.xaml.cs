﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COVID.Services;
using COVID.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}