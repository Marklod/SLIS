﻿using SLIS.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SLIS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
            // MainPage = new NavigationPage(new Temp());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
