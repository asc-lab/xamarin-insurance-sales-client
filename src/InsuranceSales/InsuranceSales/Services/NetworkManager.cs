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
        private readonly IOfferService _offerService;
        private readonly IProductService _productService;
        #endregion

        public NetworkManager()
        {
            HttpClient.BaseAddress = AppSettings.BackendUrl;
            _productService = AppSettings.UseMockDataService
                ? DependencyService.Resolve<IProductService>()
                : RestService.For<IProductService>(HttpClient);

            _offerService = AppSettings.UseMockDataService
                ? DependencyService.Resolve<IOfferService>()
                : RestService.For<IOfferService>(HttpClient);
        }

        public Task<IEnumerable<ProductModel>> GetProductsAsync() => _productService.FetchAsync();

        public Task<ProductModel> GetProductByCodeAsync(string productId) => _productService.GetByCodeAsync(productId);

        public Task<CreateOfferResult> GetPolicyPricesAsync(CreateOfferRequest newOffer) => _offerService.GetPolicyPricesAsync(newOffer);
    }
}
