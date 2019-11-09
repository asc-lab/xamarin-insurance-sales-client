using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HttpTracer;
using InsuranceSales.Interfaces;
using InsuranceSales.Models;
using Refit;

namespace InsuranceSales.Services
{
    public class NetworkManager
    {
        private readonly static HttpClient _httpClient = new HttpClient(new HttpTracerHandler());
        private readonly IProductsService _productsService;

        public NetworkManager()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.backendUrl);
            _productsService = RestService.For<IProductsService>(_httpClient);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return _productsService.Fetch();
        }
    }
}
