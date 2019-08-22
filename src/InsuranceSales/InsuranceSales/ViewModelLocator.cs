using InsuranceSales.ViewModels;

namespace InsuranceSales
{
    public class ViewModelLocator
    {
        private static ProductsPageViewModel productsPageViewModel;
        public static ProductsPageViewModel ProductsPageViewModel => productsPageViewModel ?? (productsPageViewModel = new ProductsPageViewModel());
    }
}
