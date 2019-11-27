using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceSales.Models;
using InsuranceSales.Models.Product;
using Refit;

namespace InsuranceSales.Interfaces
{
    public interface IProductsService
    {
        [Get("/products")]
        Task<IEnumerable<ProductModel>> Fetch();
    }
}
