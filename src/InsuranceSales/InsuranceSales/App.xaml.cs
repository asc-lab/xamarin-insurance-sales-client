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

                // TODO: Connect to API
                if (AppSettings.UseMockAuthentication)
                    DependencyService.Register<IAuthenticationService, MockAuthenticationService>();

                if (AppSettings.UseMockDataService)
                {
                    DependencyService.Register<IProductService, MockProductService>();
                    DependencyService.Register<IPolicyService, MockPolicyService>();
                }
                DependencyService.Register<IDialogService, DialogService>();

                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
