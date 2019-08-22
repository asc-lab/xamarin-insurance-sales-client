using System.Collections.ObjectModel;
using System.Threading.Tasks;
using InsuranceSales.Models;
using InsuranceSales.Views;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products { get; set; }

        public ProductsPageViewModel()
        {
            if (DesignMode.IsDesignModeEnabled)
            {
                Header = "Available products";
                Products = new ObservableCollection<Product>
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

        private Task LoadData() => Task.CompletedTask;
    }
}
