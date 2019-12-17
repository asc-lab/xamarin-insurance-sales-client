using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer.Dto;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceSales.Services
{
    public class MockPolicyService : IPolicyService
    {
        public Task<CreateOfferResult> GetPolicyPricesAsync(CreateOfferRequest request)
        {
            var value = new Random().Next().ToString(CultureInfo.CurrentCulture);
            var result = new CreateOfferResult
            {
                OfferNumber = Guid.NewGuid().ToString(),
                TotalPrice = 21.37m,
                CoversPrices = request?.SelectedCovers?.ToDictionary(k => k, _ => decimal.Parse(value, CultureInfo.CurrentCulture)),
            };
            return Task.FromResult(result);
        }

        public Task<object> SendOffer(object request)
        {
            var result = new object();
            return Task.FromResult(result);
        }
    }
}
