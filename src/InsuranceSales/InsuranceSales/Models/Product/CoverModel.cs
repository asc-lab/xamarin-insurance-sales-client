using Newtonsoft.Json;
using System;

namespace InsuranceSales.Models.Product
{
    public class CoverModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

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
