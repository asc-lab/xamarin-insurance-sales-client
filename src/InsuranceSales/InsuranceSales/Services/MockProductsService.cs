using InsuranceSales.Interfaces;
using InsuranceSales.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceSales.Models.Product;

namespace InsuranceSales.Services
{
    public class MockProductsService : IProductsService
    {
        public async Task<IEnumerable<ProductModel>> Fetch()
        {
            await Task.Delay(1000);

            var products = new List<ProductModel>
            {
                new ProductModel
                {
                    Name = "Super uber product",
                    Description = "Super uber description",
                    Code = "SUP",
                    Image = "homeInsurance.jpg",
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
                    Image = "homeInsurance.jpg",
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

            return products.AsEnumerable();
        }
    }
}
