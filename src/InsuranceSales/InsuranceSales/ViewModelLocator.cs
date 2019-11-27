using InsuranceSales.ViewModels;

namespace InsuranceSales
{
    public static class ViewModelLocator
    {
        private static ProductListViewModel _productsViewModel;

        public static ProductListViewModel ProductsViewModel => _productsViewModel ??= new ProductListViewModel();   
    }
}