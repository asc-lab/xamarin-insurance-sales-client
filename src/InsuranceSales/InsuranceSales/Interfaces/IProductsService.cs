using InsuranceSales.Models.Product;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IProductsService
    {
        [Get("/products")]
        Task<IEnumerable<ProductModel>> Fetch();

        [Get("/products/{productId}")]
        Task<ProductModel> GetById(Guid productId);
    }
}
