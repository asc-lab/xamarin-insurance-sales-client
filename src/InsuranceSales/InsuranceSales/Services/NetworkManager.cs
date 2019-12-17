using HttpTracer;
using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer.Dto;
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

        public Task<ProductModel> GetProductByCodeAsync(string productId) => _productService.GetByCodeAsync(productId);

        public Task<CreateOfferResult> GetPolicyByNumberAsync(string policyNumber) => _policyService.GetPolicyByNumberAsync(policyNumber);

        public Task<CreateOfferResult> GetPolicyPricesAsync(CreateOfferRequest newOffer) => _policyService.GetPolicyPricesAsync(newOffer);

        public Task<object> SendOfferAsync(object request) => _policyService.SendOffer(request);
    }
}
