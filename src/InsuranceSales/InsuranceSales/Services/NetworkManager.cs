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
        private static readonly HttpClient HttpClient = new HttpClient(new HttpTracerHandler());
        private readonly IProductsService _productsService;

        public NetworkManager()
        {
            HttpClient.BaseAddress = new Uri(AppSettings.backendUrl);
            _productsService = RestService.For<IProductsService>(HttpClient);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return _productsService.Fetch();
        }
    }
}
