﻿using InsuranceSales.Interfaces;
using InsuranceSales.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace InsuranceSales
{
    public partial class App
    {
        private static NetworkManager _networkManager;
        public static NetworkManager NetworkManager => _networkManager ??= new NetworkManager();

        public App()
        {
            try
            {
                InitializeComponent();

                MainPage = new AppShell();

                // TODO: Connect to API
                if (AppSettings.UseMockAuthentication)
                    DependencyService.Register<IAuthenticationService, MockAuthenticationService>();

                if (AppSettings.UseMockDataService)
                    DependencyService.Register<IProductsService, MockProductsService>();

                DependencyService.Register<IDialogService, DialogService>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
