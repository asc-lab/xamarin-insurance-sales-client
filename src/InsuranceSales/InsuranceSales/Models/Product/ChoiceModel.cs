using Newtonsoft.Json;

namespace InsuranceSales.Models.Product
{

    public class Choice
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
