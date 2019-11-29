using InsuranceSales.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Products
{
    [QueryProperty(nameof(ProductDetailsViewModel.ProductId), "productId")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage
    {
        public string ProductId { set => SetProductId(Guid.Parse(value)); }

        public ProductDetailsPage() => InitializeComponent();

        private void SetProductId(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException(nameof(productId));

            if (BindingContext is ProductDetailsViewModel vm)
                vm.ProductId = productId;
        }
    }
}