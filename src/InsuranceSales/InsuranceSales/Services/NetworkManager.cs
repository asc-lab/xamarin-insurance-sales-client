﻿using HttpTracer;
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
        #region SERVICES
        private static readonly HttpClient HttpClient = new HttpClient(new HttpTracerHandler());
        private readonly IProductsService _productsService;
        #endregion

        public NetworkManager()
        {
            HttpClient.BaseAddress = AppSettings.BackendUrl;
            _productsService = AppSettings.UseMockDataService 
                ? DependencyService.Resolve<IProductsService>() 
                : RestService.For<IProductsService>(HttpClient);
        }

        public Task<IEnumerable<ProductModel>> GetProductsAsync() => _productsService.FetchAsync();

        public Task<ProductModel> GetProductByIdAsync(Guid productId) => _productsService.GetByIdAsync(productId);
    }
}
