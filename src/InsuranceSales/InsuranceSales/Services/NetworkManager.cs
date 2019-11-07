using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceSales.Interfaces;
using InsuranceSales.Models;
using Refit;

namespace InsuranceSales.Services
{
    public class NetworkManager
    {
        private readonly IProductsService _productsService;

        public NetworkManager()
        {
            _productsService = RestService.For<IProductsService>(AppSettings.backendUrl);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return _productsService.Fetch();
        }
    }
}
