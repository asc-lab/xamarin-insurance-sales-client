using Newtonsoft.Json;

namespace InsuranceSales.Models.Policy
{
    public class AddressModel
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }
    }
}
