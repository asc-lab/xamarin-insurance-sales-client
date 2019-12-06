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
                Covers = new[]
                {
                    new CoverModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "AC",
                        Name = "Assistance",
                        Optional = true,
                        SumInsured = new Random().Next()
                    },
                },
                Questions = new[]
                {
                    new QuestionModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "NUM_OF_CLAIMS",
                        Index = 1,
                        Text = "Number of claims in last 5 years",
                        Type = QuestionTypeEnum.Numeric,
                    },
                },
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
                        Code = "FR",
                        Name = "Fire",
                        Optional = false,
                        SumInsured = new Random().Next()
                    },
                    new CoverModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "FL",
                        Name = "Flood",
                        Optional = false,
                        SumInsured = new Random().Next()
                    },
                    new CoverModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "TH",
                        Name = "Theft",
                        Optional = false,
                        SumInsured = new Random().Next()
                    },
                    new CoverModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "AC",
                        Name = "Assistance",
                        Optional = false,
                        SumInsured = new Random().Next()
                    },
                },
                Questions = new[]
                {
                    new QuestionModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "CT",
                        Index = 1,
                        Text = "Cultivation type",
                        Type = QuestionTypeEnum.Choice,
                        Choices = new[]
                        {
                            new ChoiceModel
                            {
                                Label = "Crop",
                                Code = "ZB"
                            },
                            new ChoiceModel
                            {
                                Label = "Vegetable",
                                Code = "KW"
                            },
                        },
                    },
                    new QuestionModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "AREA",
                        Index = 3,
                        Text = "Area",
                        Type = QuestionTypeEnum.Numeric,
                    },
                    new QuestionModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "NUM_OF_CLAIMS",
                        Index = 2,
                        Text = "Number of claims in last 5 years " ,
                        Type = QuestionTypeEnum.Numeric,
                    },
                    new QuestionModel
                    {
                        Id = Guid.NewGuid(),
                        Code = "FLOOD_AREA",
                        Index = 4,
                        Text = "Located in flood risk area",
                        Type = QuestionTypeEnum.Choice,
                        Choices = new[]
                        {
                            new ChoiceModel
                            {
                                Label = "Yes",
                                Code = "YES"
                            },
                            new ChoiceModel
                            {
                                Label = "No",
                                Code = "NO"
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
