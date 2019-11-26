using InsuranceSales.ViewModels;

namespace InsuranceSales
{
    public static class ViewModelLocator
    {
        private static ProductsPageViewModel _productsPageViewModel;

        public static ProductsPageViewModel ProductsPageViewModel => _productsPageViewModel ??= new ProductsPageViewModel();
    }
}