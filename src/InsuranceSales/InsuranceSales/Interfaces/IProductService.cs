using InsuranceSales.Models.Product;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IProductService
    {
        [Get("/products")]
        Task<IEnumerable<ProductModel>> FetchAsync();

        [Get("/products/{productCode}")]
        Task<ProductModel> GetByCodeAsync(string productCode);
    }
}
