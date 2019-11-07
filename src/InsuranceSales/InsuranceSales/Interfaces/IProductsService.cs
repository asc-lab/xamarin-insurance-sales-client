using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceSales.Models;
using Refit;

namespace InsuranceSales.Interfaces
{
    public interface IProductsService
    {
        [Get("/products")]
        Task<IEnumerable<Product>> Fetch();
    }
}
