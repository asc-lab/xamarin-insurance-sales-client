using InsuranceSales.Models.Product;
using Newtonsoft.Json;

namespace InsuranceSales.Extensions
{
    public static class ProductExtensions
    {
        public static string ToJson(this ProductModel[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

}
