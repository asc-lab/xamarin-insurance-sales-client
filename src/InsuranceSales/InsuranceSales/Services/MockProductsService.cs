using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceSales.Services
{
    public class MockProductsService : IProductsService
    {
        public async Task<IEnumerable<ProductModel>> FetchAsync()
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
                    MaxNumberOfInsured = 500L,
                    Questions = new[]
                    {
                        new QuestionModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "",
                            Index = 100L,
                            Text = $"QUESTION + {new Random().Next()}" ,
                            Type = QuestionTypeEnum.Choice,
                            Choices = new[]
                            {
                                new ChoiceModel
                                {
                                    Label = "label",
                                    Code = "code"
                                },
                                new ChoiceModel
                                {
                                    Label = "label",
                                    Code = "code"
                                },
                                new ChoiceModel
                                {
                                    Label = "label",
                                    Code = "code"
                                },
                            },
                        },
                    },
                    Covers = new[]
                    {
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
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
                    Name = "Happy farm",
                    Description = " Farm insurance",
                    Code = "HF",
                    Image = "http://mn.lab.software.altkom.pl/static/farm.jpg",
                    MaxNumberOfInsured = 1,
                    Covers = new[]
                    {
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "NO",
                            Name = "Test cover",
                            Optional = false,
                            SumInsured = 1000L
                        }
                    },
                    Questions = new[]
                    {
                        new QuestionModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "NO",
                            Index = 100L,
                            Text = $"QUESTION + {new Random().Next()}" ,
                            Type = QuestionTypeEnum.Choice,
                            Choices = new[]
                            {
                                new ChoiceModel
                                {
                                    Label = "label",
                                    Code = "code"
                                },
                                new ChoiceModel
                                {
                                    Label = "label",
                                    Code = "code"
                                },
                                new ChoiceModel
                                {
                                    Label = "label",
                                    Code = "code"
                                },
                            },
                        },
                    },
                }
            };
            return products.AsEnumerable();
        }

        public async Task<ProductModel> GetByIdAsync(Guid productId)
        {
            await Task.Delay(500);
            var productModel = new ProductModel
            {
                Id = productId,
                Name = "Happy Driver",
                Description = " Car insurance",
                Code = "HD",
                Image = "http://mn.lab.software.altkom.pl/static/car.jpg",
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
                },
                Questions = new[]
                {
                    new QuestionModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "NO",
                        Index = 100L,
                        Text = $"QUESTION + {new Random().Next()}" ,
                        Type = QuestionTypeEnum.Choice,
                        Choices = new[]
                        {
                            new ChoiceModel
                            {
                                Label = "label",
                                Code = "code"
                            },
                            new ChoiceModel
                            {
                                Label = "label",
                                Code = "code"
                            },
                            new ChoiceModel
                            {
                                Label = "label",
                                Code = "code"
                            },
                        },
                    },
                },
            };
            return productModel;
        }
    }
}
