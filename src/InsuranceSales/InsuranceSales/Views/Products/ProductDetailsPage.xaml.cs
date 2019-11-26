using InsuranceSales.ViewModels;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPageBase<ProductDetailsViewModel>
    {
        public ProductDetailsPage() => InitializeComponent();
    }
}