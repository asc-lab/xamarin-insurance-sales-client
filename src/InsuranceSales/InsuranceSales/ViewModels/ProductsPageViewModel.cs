using InsuranceSales.Models.Product;
using InsuranceSales.Views.Login;
using MvvmHelpers;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<ProductModel> Products { get; } = new ObservableRangeCollection<ProductModel>();

        public ProductsPageViewModel()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                Products = new ObservableRangeCollection<ProductModel>
                {
                    new ProductModel
                    {
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
        }

        public override async Task InitializeAsync()
        {
            Header = "Available products";

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "AUTH_MSG", sender => LoadData().ConfigureAwait(false));

            if (!AuthenticationService.IsAuthenticated())
                await Shell.Current.Navigation.PushModalAsync(new LoginPage()).ConfigureAwait(false);
        }

        private async Task LoadData()
        {
            IsBusy = true;
            var products = await App.NetworkManager.GetProducts().ConfigureAwait(false);
            if (products.Any())
            {
                Products.Clear();
                Products.AddRange(products);
            }
            IsBusy = false;
        }
    }
}
