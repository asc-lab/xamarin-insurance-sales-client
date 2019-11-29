using InsuranceSales.Interfaces;
using InsuranceSales.Models.Product;
using InsuranceSales.Resources;
using MvvmHelpers;
using System;
using System.Linq;
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
        public ICommand ListItemClickedCommand => _listItemClickedCommand ??= new Command<ProductModel>(async product => await ShowProductDetails(product.Id));

        #endregion

        /// <summary>
        /// TESTING ONLY
        /// </summary>
        public ProductListViewModel(IAuthenticationService authenticationService)
            : base(authenticationService)
        {
            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessageKeys.AUTH_MSG, async _ => await LoadData());
            MessagingCenter.Subscribe<AppShell>(this, MessageKeys.AUTH_MSG, async _ => await LoadData());
        }

        public ProductListViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        {
            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessageKeys.AUTH_MSG, async _ => await LoadData());
            MessagingCenter.Subscribe<AppShell>(this, MessageKeys.AUTH_MSG, async _ => await LoadData());
        }

        public override Task InitializeAsync()
        {
            Header = "Available products";

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

        public static async Task ShowProductDetails(Guid productId)
        {
            await Shell.Current.GoToAsync($"/Product/Details?productId={productId}");
        }
    }
}
