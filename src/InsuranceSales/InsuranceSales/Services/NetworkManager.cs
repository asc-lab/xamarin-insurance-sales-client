using HttpTracer;
using InsuranceSales.Interfaces;
using InsuranceSales.Models.Product;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.Services
{
    public class NetworkManager
    {
        private static readonly HttpClient HttpClient = new HttpClient(new HttpTracerHandler());
        private readonly IProductsService _productsService;

        public NetworkManager()
        {
            HttpClient.BaseAddress = new Uri(AppSettings.BackendUrl);
            //_productsService = RestService.For<IProductsService>(HttpClient);
            _productsService = DependencyService.Resolve<IProductsService>();
        }

        public Task<IEnumerable<ProductModel>> GetProducts()
        {
            return _productsService.Fetch();
        }   
        
        public Task<ProductModel> GetProductByIdAsync(Guid productId)
        {
            return _productsService.GetById(productId);
        }
    }
}
