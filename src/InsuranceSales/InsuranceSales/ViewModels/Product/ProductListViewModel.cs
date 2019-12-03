using InsuranceSales.Interfaces;
using InsuranceSales.Models.Product;
using InsuranceSales.Resources;
using InsuranceSales.ViewModels.Login;
using MvvmHelpers;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Product
{
    public class ProductListViewModel : ViewModelBase
    {
        public ObservableRangeCollection<ProductModel> Products { get; } = new ObservableRangeCollection<ProductModel>();

        #region COMMANDS
        private ICommand _listItemClickedCommand;
        public ICommand ListItemClickedCommand => _listItemClickedCommand ??= new Command<string>(async productCode => await ShowProductDetails(productCode));

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
            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessageKeys.AUTH_MSG, async _ => await LoadData());

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

        public static async Task ShowProductDetails(string productCode)
        {
            await Shell.Current.GoToAsync($"/Product/Details?productCode={productCode}");
        }
    }
}
