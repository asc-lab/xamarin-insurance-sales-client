using InsuranceSales.Models.Product;
using InsuranceSales.ViewModels.Product;
using Xamarin.Forms;

namespace InsuranceSales.Views.Products
{
    public partial class ProductListPage
    {
        public ProductListPage() => InitializeComponent();

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var product = (e.SelectedItem as ProductModel);
            if (BindingContext is ProductListViewModel viewModel &&
                !string.IsNullOrWhiteSpace(product?.Code) &&
                viewModel.ListItemClickedCommand.CanExecute(product.Code))
                viewModel.ListItemClickedCommand.Execute(product.Code);

            ((ListView)sender).SelectedItem = null;
        }
    }
}
