using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using Refit;
using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IPolicyService
    {
        [Post("/offers")]
        Task<CreateOfferResult> GetPolicyPricesAsync([Body]CreateOfferRequest request);

        [Post("/offers/{test}")]
        Task<object> SendOffer([Body]object request);

        [Get("/policies/{policyNumber}")]
        Task<PolicyModel> GetPolicyByNumberAsync(string policyNumber);
    }
}
