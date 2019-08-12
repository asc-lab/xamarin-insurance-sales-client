using System.Threading.Tasks;
using InsuranceSales.Interfaces;
using InsuranceSales.Models;
using InsuranceSales.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        public ObservableRangeCollection<Product> Products { get; set; }

        public ProductsPageViewModel()
        {
            _authenticationService = DependencyService.Get<IAuthenticationService>();
        }

        public override async Task InitializeAsync()
        {
            if (!_authenticationService.IsAuthenticated())
                await Shell.Current.Navigation.PushModalAsync(new LoginPage());

            Header = "Available products";
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
