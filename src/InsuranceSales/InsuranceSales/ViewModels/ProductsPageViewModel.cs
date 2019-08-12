using System.Threading.Tasks;
using InsuranceSales.Models;
using InsuranceSales.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private ObservableRangeCollection<Product> products;

        public ObservableRangeCollection<Product> Products { get => products; set => SetProperty(ref products, value); }

        public override async Task InitializeAsync()
        {
            Header = "Available products";

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "AUTH_MSG", async (sender) => await LoadData());

            if (!AuthenticationService.IsAuthenticated())
                await Shell.Current.Navigation.PushModalAsync(new LoginPage());
        }

        private async Task LoadData()
        {
            Products = new ObservableRangeCollection<Product>
            {
                new Product
                {
                    Name = "Super uber product",
                    Description = "Super uber description",
                    Code = "SUP",
                    Image = "DevImage",
                    MaxNumberOfInsured = 1,
                    Covers = new Cover[]
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
                    Image = "DevImage",
                    MaxNumberOfInsured = 1,
                    Covers = new Cover[]
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
}
