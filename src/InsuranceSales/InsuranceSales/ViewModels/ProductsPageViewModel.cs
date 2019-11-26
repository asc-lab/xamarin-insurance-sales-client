using System.Linq;
using System.Threading.Tasks;
using InsuranceSales.Models;
using InsuranceSales.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Product> Products { get; } = new ObservableRangeCollection<Product>();

        public ProductsPageViewModel()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                Products = new ObservableRangeCollection<Product>
                {
                    new Product
                    {
                        Name = "Super uber product",
                        Description = "Super uber description",
                        Code = "SUP",
                        Image = "",
                        MaxNumberOfInsured = 1,
                        Covers = new[]
                        {
                            new Cover
                            {
                                Code = "TEST",
                                Name = "Test cover",
                                Optional = false,
                                SumInsured = 1000L
                            }
                        }
                    },
                    new Product
                    {
                        Name = "Super uber product",
                        Description = "Super uber description",
                        Code = "SUP",
                        Image = "",
                        MaxNumberOfInsured = 1,
                        Covers = new[]
                        {
                            new Cover
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
                IsBusy = false;
                Products.Clear();
                Products.AddRange(products);
            }
        }
    }
}
