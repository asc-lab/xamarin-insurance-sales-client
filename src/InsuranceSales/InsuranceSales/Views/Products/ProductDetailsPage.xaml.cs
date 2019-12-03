using InsuranceSales.ViewModels.Product;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Products
{
    [QueryProperty(nameof(ProductCode), "productCode")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage
    {
        public string ProductCode
        {
            get => (BindingContext as ProductDetailsViewModel).ProductCode;
            set => (BindingContext as ProductDetailsViewModel).ProductCode = value;
        }

        public ProductDetailsPage() => InitializeComponent();
    }
}