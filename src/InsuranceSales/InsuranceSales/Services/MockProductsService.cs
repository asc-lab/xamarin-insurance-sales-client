using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceSales.Interfaces;
using InsuranceSales.Models;

namespace InsuranceSales.Services
{
    public class MockProductsService : IProductsService
    {
        public async Task<IEnumerable<Product>> Fetch()
        {
            await Task.Delay(1000);

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Super uber product",
                    Description = "Super uber description",
                    Code = "SUP",
                    Image = "homeInsurance.jpg",
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
                    Image = "homeInsurance.jpg",
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

            return products.AsEnumerable();
        }
    }
}
