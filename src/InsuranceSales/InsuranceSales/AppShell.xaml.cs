﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using InsuranceSales.Views.Policy;
using InsuranceSales.Views.Products;
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
