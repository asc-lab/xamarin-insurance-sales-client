using InsuranceSales.Interfaces;
using InsuranceSales.Resources;
using InsuranceSales.Views.Login;
using InsuranceSales.Views.Policy;
using InsuranceSales.Views.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace InsuranceSales
{
    public partial class AppShell
    {
        public static readonly IReadOnlyDictionary<string, Type> RoutingTable = new Dictionary<string, Type>
        {
            { "Policy/CreateOffer", typeof(PolicyOfferFormPage) },
            { "Policy/Details", typeof(PolicyDetailsPage) },
            { "Product/Details", typeof(ProductDetailsPage) },
        };

        public AppShell()
        {
            try
            {
                InitializeComponent();

                foreach (var (route, viewModelType) in RoutingTable)
                    Routing.RegisterRoute(route, viewModelType);

                var loginPage = new LoginPage();
                var authService = DependencyService.Resolve<IAuthenticationService>();
                if (authService.IsAuthenticated()) // TODO
                    MessagingCenter.Send(loginPage, MessageKeys.AUTH_MSG);
                else
                    Navigation.PushModalAsync(loginPage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
