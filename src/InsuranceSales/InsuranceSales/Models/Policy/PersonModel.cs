using Newtonsoft.Json;

namespace InsuranceSales.Models.Policy
{
    public class PersonModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("taxId")]
        public string TaxId { get; set; }
    }
}
