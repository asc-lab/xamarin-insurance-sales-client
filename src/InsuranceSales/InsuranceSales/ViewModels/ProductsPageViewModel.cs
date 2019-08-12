using System.Threading.Tasks;
using InsuranceSales.Models;
using MvvmHelpers;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Product> Products { get; set; }

        public ProductsPageViewModel()
        {
            Task.Run(async () =>
            {
                await InitializeAsync();
            });
        }

        public override Task InitializeAsync()
        {
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

            return base.InitializeAsync();
        }
    }
}
