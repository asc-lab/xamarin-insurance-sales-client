using InsuranceSales.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Products
{
    //[QueryProperty("ProductId", "productId")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage
    {
        //public string ProductId { get => throw new NotImplementedException(); set => SetProductId(value); }

        public ProductDetailsPage() => InitializeComponent();

        private void SetProductId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            var productId = Uri.UnescapeDataString(value);
            var vm = new ProductDetailsViewModel { ProductId = Guid.Parse(productId) };
            BindingContext = vm;
        }
    }
}