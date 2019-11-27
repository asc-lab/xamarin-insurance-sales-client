using Newtonsoft.Json;

namespace InsuranceSales.Models.Product
{

    public class CoverModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("optional")]
        public bool Optional { get; set; }

        [JsonProperty("sumInsured", NullValueHandling = NullValueHandling.Ignore)]
        public long? SumInsured { get; set; }
    }
}
