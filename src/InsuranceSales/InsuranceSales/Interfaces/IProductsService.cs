using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceSales.Models;

namespace InsuranceSales.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> FetchAsync();
    }
}
