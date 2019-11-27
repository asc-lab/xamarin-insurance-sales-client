using InsuranceSales.Models.Product;
using InsuranceSales.ViewModels;
using System;
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

            var productId = (e.SelectedItem as ProductModel)?.Id;
            if (BindingContext is ProductListViewModel viewModel &&
                productId.GetValueOrDefault() != Guid.Empty &&
                viewModel.ListItemClickedCommand.CanExecute(productId))
                viewModel.ListItemClickedCommand.Execute(productId);

            ((ListView)sender).SelectedItem = null;
        }
    }
}
