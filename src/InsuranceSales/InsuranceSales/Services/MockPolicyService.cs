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
                Number = "",
                PolicyHolder = "",
                ProductCode = "",
                Covers = new []
                {
                    "",
                },
                DateTo = DateTime.Today.AddDays(7),
                DateFrom = DateTime.Today.AddDays(14),
                AccountNumber = "",
                TotalPremium = 2.30m,
            },    
            new PolicyModel
            {
                Number = "",
                PolicyHolder = "",
                ProductCode = "",
                Covers = new []
                {
                    "",
                },
                DateTo = DateTime.Today.AddDays(7),
                DateFrom = DateTime.Today.AddDays(14),
                AccountNumber = "",
                TotalPremium = 2.30m,
            },
        };

        public Task<CreateOfferResultDto> CreateOfferAsync(CreateOfferRequestDto request, string agentLogin)
        {
            var value = new Random().Next().ToString(CultureInfo.CurrentCulture);
            var result = new CreateOfferResultDto
            {
                OfferNumber = Guid.NewGuid().ToString(),
                TotalPrice = 21.37m,
                CoversPrices = request?.SelectedCovers?.ToDictionary(k => k, _ => decimal.Parse(value, CultureInfo.CurrentCulture)),
            };
            return Task.FromResult(result);
        }

        public Task<CreatePolicyResultDto> CreatePolicyAsync(CreatePolicyRequestDto request, string agentLogin)
        {
            var result = new CreatePolicyResultDto { PolicyNumber = Policies?.FirstOrDefault()?.Number };
            return Task.FromResult(result);
        }

        public Task<PolicyModel> GetPolicyByNumberAsync(string policyNumber)
        {
            var result = Policies?.FirstOrDefault();
            return Task.FromResult(result);
        }
    }
}
