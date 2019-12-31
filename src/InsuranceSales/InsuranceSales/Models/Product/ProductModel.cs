using InsuranceSales.Models.Policy;
using InsuranceSales.Serialization;
using Newtonsoft.Json;
using System;

namespace InsuranceSales.Models.Product
{
    public class ProductModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("covers")]
        public CoverModel[] Covers { get; set; }

        [JsonProperty("questions")]
        public QuestionModel[] Questions { get; set; }

        [JsonProperty("maxNumberOfInsured")]
        public long MaxNumberOfInsured { get; set; }

        public static ProductModel[] FromJson(string json) => JsonConvert.DeserializeObject<ProductModel[]>(json, Converter.Settings);
    }
}
