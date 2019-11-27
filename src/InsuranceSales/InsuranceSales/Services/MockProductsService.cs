using InsuranceSales.Interfaces;
using InsuranceSales.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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

        public async Task<ProductModel> GetById(Guid productId)
        {
            await Task.Delay(500);
            var productModel = new ProductModel
            {
                Id = productId,
                Name = "Super uber product",
                Description = "Super uber description",
                Code = "SUP",
                Image = "homeInsurance.jpg",
                MaxNumberOfInsured = new Random().Next(),
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
            };
            return productModel;
        }
    }
}
