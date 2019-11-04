using System.Linq;
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
        private readonly IProductsService service;

        public ObservableRangeCollection<Product> Products { get; set; } = new ObservableRangeCollection<Product>();

        public ProductsPageViewModel()
        {
            service = DependencyService.Get<IProductsService>();

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
                        Image = "",
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

        public override async Task InitializeAsync()
        {
            Header = "Available products";

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "AUTH_MSG", (sender) => LoadData().ConfigureAwait(false));

            if (!AuthenticationService.IsAuthenticated())
                await Shell.Current.Navigation.PushModalAsync(new LoginPage());
        }

        private async Task LoadData()
        {
            IsBusy = true;
            var results = await service.FetchAsync();
            if(results.Count() > 0)
            {
                IsBusy = false;
                Products.Clear();
                Products.AddRange(results);
            }
        }
    }
}
