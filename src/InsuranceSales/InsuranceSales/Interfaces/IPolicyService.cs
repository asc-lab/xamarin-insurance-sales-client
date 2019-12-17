using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Policy.Dto;
using Refit;
using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IPolicyService
    {
        [Post("/offer")]
        Task<CreateOfferResultDto> CreateOfferAsync([Body]CreateOfferRequestDto request, [Header("AgentLogin")]string agentLogin);

        [Post("/policy")]
        Task<CreatePolicyResultDto> CreatePolicyAsync([Body]CreatePolicyRequestDto request, [Header("AgentLogin")]string agentLogin);

        [Get("/policy/{policyNumber}")]
        Task<PolicyModel> GetPolicyByNumberAsync(string policyNumber);
    }
}
