using InsuranceSales.Models.Offer.Dto;
using Refit;
using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IOfferService
    {
        [Post("/offers")]
        Task<CreateOfferResult> GetPolicyPricesAsync([Body]CreateOfferRequest request);
    }
}
