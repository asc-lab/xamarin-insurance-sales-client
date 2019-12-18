using HttpTracer;
using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Policy.Dto;
using InsuranceSales.Models.Product;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.Services
{
    public class NetworkManager
    {
        #region SERVICES
        private static readonly HttpClient HttpClient = new HttpClient(new HttpTracerHandler());
        private readonly IPolicyService _policyService;
        private readonly IProductService _productService;
        #endregion

        public NetworkManager()
        {
            HttpClient.BaseAddress = AppSettings.BackendUrl;

            _productService = AppSettings.UseMockDataService
                ? DependencyService.Resolve<IProductService>()
                : RestService.For<IProductService>(HttpClient);

            _policyService = AppSettings.UseMockDataService
                ? DependencyService.Resolve<IPolicyService>()
                : RestService.For<IPolicyService>(HttpClient);
        }

        public Task<IEnumerable<ProductModel>> GetProductsAsync() => _productService.FetchAsync();

        public Task<ProductModel> GetProductByCodeAsync(string productCode) => _productService.GetByCodeAsync(productCode);

        public Task<PolicyModel> GetPolicyByNumberAsync(string policyNumber) => _policyService.GetPolicyByNumberAsync(policyNumber);

        public Task<CreateOfferResultDto> CreateOfferAsync(CreateOfferRequestDto request, string agentLogin = AppSettings.AgentLogin) =>
            _policyService.CreateOfferAsync(request, agentLogin);

        public Task<CreatePolicyResultDto> CreatePolicyAsync(CreatePolicyRequestDto request, string agentLogin = AppSettings.AgentLogin) =>
            _policyService.CreatePolicyAsync(request, agentLogin);
    }
}
