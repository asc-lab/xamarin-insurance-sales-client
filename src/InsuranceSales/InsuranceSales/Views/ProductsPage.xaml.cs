using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InsuranceSales.Views
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();

            // Hide navigation bar
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}
