using InsuranceSales.Interfaces;
using InsuranceSales.Models.Product;
using InsuranceSales.Resources;
using MvvmHelpers;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductListViewModel : ViewModelBase
    {
        public ObservableRangeCollection<ProductModel> Products { get; } = new ObservableRangeCollection<ProductModel>();

        #region COMMANDS
        private ICommand _listItemClickedCommand;
        public ICommand ListItemClickedCommand => _listItemClickedCommand ??= new Command<ProductModel>( async product => await ShowProductDetails(product));

        #endregion

        /// <summary>
        /// TESTING ONLY
        /// </summary>
        public ProductListViewModel(IAuthenticationService authenticationService)
            : base(authenticationService)
        { }

        public ProductListViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        { }

        public override Task InitializeAsync()
        {
            Header = "Available products";

            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessageKeys.AUTH_MSG, async sender => await LoadData());
            MessagingCenter.Subscribe<AppShell>(this, MessageKeys.AUTH_MSG, async sender => await LoadData());

            return base.InitializeAsync();
        }

        private async Task LoadData()
        {
            IsBusy = true;
            var products = await App.NetworkManager.GetProductsAsync();
            if (products.Any())
            {
                IsBusy = false;
                Products.Clear();
                Products.AddRange(products);
            }
        }

        public async Task ShowProductDetails(ProductModel product)
        {
            await Shell.Current.GoToAsync("/Product/Details");
            MessagingCenter.Send(this, "PRODUCT_DETAILS", product);
        }
    }
}
