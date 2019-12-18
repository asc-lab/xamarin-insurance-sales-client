using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Policy.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceSales.Services
{
    public class MockPolicyService : IPolicyService
    {
        private static readonly IReadOnlyCollection<PolicyModel> Policies = new[]
        {
            new PolicyModel
            {
                Number = "08F377C4-9C15-4B84-88B6-B8DDA21831C5",
                PolicyHolder = "Ringo Starr",
                ProductCode = "CAR",
                Covers = new []
                {
                    "C1",
                    "K1",
                    "OC"
                },
                DateTo = DateTime.Today.AddDays(7),
                DateFrom = DateTime.Today.AddDays(14),
                AccountNumber = "A26251D3-E1F9-4478-B2B0-31E78392CB4C",
                TotalPremium = 2.30m,
            },
            new PolicyModel
            {
                Number = "62F40D04-3C7F-4EEC-89D6-B8DF2CED8387",
                PolicyHolder = "Mungo Jerry",
                ProductCode = "FARM",
                Covers = new []
                {
                    "C1",
                    "C2",
                    "C3"
                },
                DateTo = DateTime.Today.AddDays(7),
                DateFrom = DateTime.Today.AddDays(14),
                AccountNumber = "6BCCC002-7635-4141-A233-2D477AB89777",
                TotalPremium = 2.30m,
            },
        };

        public Task<CreateOfferResultDto> CreateOfferAsync(CreateOfferRequestDto request, string agentLogin)
        {
            var value = new Random().Next().ToString(CultureInfo.CurrentCulture);
            var result = new CreateOfferResultDto
            {
                OfferNumber = Guid.NewGuid().ToString(),
                TotalPrice = new Random().Next(),
                CoversPrices = request?.SelectedCovers?.ToDictionary(k => k, _ => decimal.Parse(value, CultureInfo.CurrentCulture)),
            };
            return Task.FromResult(result);
        }

        public Task<CreatePolicyResultDto> CreatePolicyAsync(CreatePolicyRequestDto request, string agentLogin)
        {
            var index = new Random().Next(0, Policies.Count);
            var result = new CreatePolicyResultDto { PolicyNumber = Policies?.ElementAtOrDefault(index)?.Number };
            return Task.FromResult(result);
        }

        public Task<PolicyModel> GetPolicyByNumberAsync(string policyNumber)
        {
            var index = new Random().Next(0, Policies.Count);
            var result = Policies?.ElementAtOrDefault(index);
            return Task.FromResult(result);
        }
    }
}
