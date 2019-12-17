using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Products
{
    [QueryProperty(nameof(ProductCode), "productCode")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage
    {
        public string ProductCode { get => ViewModel.ProductCode; set => ViewModel.ProductCode = value; }

        public ProductDetailsPage() => InitializeComponent();
    }
}