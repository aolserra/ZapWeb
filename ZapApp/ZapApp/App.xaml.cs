﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZapApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Inicio();
            MainPage = new NavigationPage(new ListagemMensagens());
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
