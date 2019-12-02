using System;
using InsuranceSales.Models.Product;
using Newtonsoft.Json;

namespace InsuranceSales.Models.Policy
{
    public class QuestionModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        public QuestionTypeEnum Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
        public ChoiceModel[] Choices { get; set; }
    }

}
