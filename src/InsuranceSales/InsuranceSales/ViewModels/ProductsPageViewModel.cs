using System;
using InsuranceSales.Models;
using MvvmHelpers;

namespace InsuranceSales.ViewModels
{
    public class ProductsPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Product> Products { get; set; }

        public ProductsPageViewModel()
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
        }
    }
}
