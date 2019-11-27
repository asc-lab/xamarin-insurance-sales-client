using InsuranceSales.Interfaces;
using InsuranceSales.Models.Product;
using InsuranceSales.Resources;
using InsuranceSales.Views.Login;
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
        public ICommand ListItemClickedCommand => _listItemClickedCommand ??= new Command<Guid>(async productId => await ShowProductDetails(productId));

        #endregion

        public ProductListViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        {
            if (DesignMode.IsDesignModeEnabled)
                Products = new ObservableRangeCollection<ProductModel>
                {
                    new ProductModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Super uber product",
                        Description = "Super uber description",
                        Code = "SUP",
                        Image = "",
                        MaxNumberOfInsured = 1,
                        Covers = new[]
                        {
                            new CoverModel
                            {
                                Code = "TEST",
                                Name = "Test cover",
                                Optional = false,
                                SumInsured = 1000L
                            }
                        }
                    },
                    new ProductModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Super uber product",
                        Description = "Super uber description",
                        Code = "SUP",
                        Image = "",
                        MaxNumberOfInsured = 1,
                        Covers = new[]
                        {
                            new CoverModel
                            {
                                Code = "TEST",
                                Name = "Test cover",
                                Optional = false,
                                SumInsured = 1000L
                            }
                        }
                    }
                };
        }

        public override async Task InitializeAsync()
        {
            Header = "Available products";

            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessageKeys.AUTH_MSG, async sender => await LoadData());

            if (!AuthenticationService.IsAuthenticated())
                await Shell.Current.Navigation.PushModalAsync(new LoginPage());
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
            var uri = $"/Product/Details?{nameof(productId)}={productId}";
            await Shell.Current.GoToAsync(uri);
        }
    }
}
