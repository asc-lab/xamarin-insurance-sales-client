using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer;
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
        private readonly IList<ProductModel> _products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Happy Driver",
                    Description = "Car insurance",
                    Code = "HD",
                    Image = "https://www.rabbiavishafran.com/wp-content/uploads/2018/08/uber-driver-2-624x416.jpg",
                    MaxNumberOfInsured = 500L,
                    Questions = new[]
                    {
                        new QuestionModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "",
                            Index = 1,
                            Text = $"QUESTION {new Random().Next()}" ,
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
                        new QuestionModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "QUESTION",
                            Index = 2,
                            Text = $"QUESTION {new Random().Next()}" ,
                            Type = QuestionTypeEnum.Numeric,
                            Choices = Array.Empty<ChoiceModel>()
                        },
                        new QuestionModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "QUESTION",
                            Index = 3,
                            Text = $"QUESTION {new Random().Next()}" ,
                            Type = QuestionTypeEnum.Text,
                            Choices = Array.Empty<ChoiceModel>()
                        },
                    },
                    Covers = new[]
                    {
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Fire",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Flood",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                    }
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Happy farm",
                    Description = " Farm insurance",
                    Code = "HF",
                    Image = "https://d279m997dpfwgl.cloudfront.net/wp/2015/05/0522_farmers.jpg",
                    MaxNumberOfInsured = 1,
                    Covers = new[]
                    {
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Fire",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Flood",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Fire",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Flood",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Fire",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Flood",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Fire",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                        new CoverModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "TEST",
                            Name = "Flood",
                            Optional = false,
                            SumInsured = new Random().Next()
                        },
                    },
                    Questions = new[]
                    {
                        new QuestionModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "NO",
                            Index = 1,
                            Text = $"QUESTION {new Random().Next()}",
                            Type = QuestionTypeEnum.Choice,
                            Choices = new[]
                            {
                                new ChoiceModel
                                {
                                    Label = "Choice 1",
                                    Code = "C1"
                                },
                                new ChoiceModel
                                {
                                    Label = "Choice 2",
                                    Code = "C2"
                                },
                                new ChoiceModel
                                {
                                    Label = "Choice 3",
                                    Code = "C3"
                                },
                            },
                        },
                    },
                }
            };

        public async Task<IEnumerable<ProductModel>> FetchAsync()
        {
            await Task.Delay(500);

            return _products.AsEnumerable();
        }

        public async Task<ProductModel> GetByCodeAsync(string productCode)
        {
            await Task.Delay(500);
            var productModel = _products.FirstOrDefault(p => p.Code == productCode);
            return productModel;
        }
    }
}
