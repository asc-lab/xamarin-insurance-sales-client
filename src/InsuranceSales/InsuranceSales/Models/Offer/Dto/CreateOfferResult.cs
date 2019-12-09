using System.Collections.Generic;

namespace InsuranceSales.Models.Offer.Dto
{
    public class CreateOfferResult
    {
        public string OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public IDictionary<string, decimal> CoversPrices { get; set; }
    }
}
