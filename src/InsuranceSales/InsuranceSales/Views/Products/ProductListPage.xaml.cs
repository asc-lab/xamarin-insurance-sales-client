using InsuranceSales.Models.Product;
using Xamarin.Forms;

namespace InsuranceSales.Views.Products
{
    public partial class ProductListPage
    {
        public ProductListPage() => InitializeComponent();

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is ProductModel product) ||
                !(sender is ListView listView))
                return;

            if (!string.IsNullOrWhiteSpace(product.Code) &&
                ViewModel.ListItemClickedCommand.CanExecute(product.Code))
                ViewModel?.ListItemClickedCommand?.Execute(product.Code);

            listView.SelectedItem = null;
        }
    }
}
