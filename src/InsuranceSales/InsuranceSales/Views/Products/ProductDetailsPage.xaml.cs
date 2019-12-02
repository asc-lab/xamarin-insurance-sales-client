using InsuranceSales.ViewModels.Product;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Products
{
    [QueryProperty(nameof(ProductDetailsViewModel.ProductId), "productId")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage
    {
        public string ProductId
        {
            get => null;
            set
            {
                var productId = Guid.Parse(value);
                if (productId == Guid.Empty && BindingContext is ProductDetailsViewModel vm)
                    vm.ProductId = productId;
            }
        }

        public ProductDetailsPage() => InitializeComponent();
    }
}