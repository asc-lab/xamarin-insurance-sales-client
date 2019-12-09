using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer.Dto;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceSales.Services
{
    public class MockOfferService : IOfferService
    {
        public Task<CreateOfferResult> GetPolicyPricesAsync(CreateOfferRequest request)
        {
            var result = new CreateOfferResult
            {
                OfferNumber = Guid.NewGuid().ToString(),
                TotalPrice = 21.37m,
                CoversPrices = request?.SelectedCovers?.ToDictionary(k => k, _ =>
                    decimal.Parse(new Random().Next().ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture)),
            };
            return Task.FromResult(result);
        }
    }
}
