using System.Threading.Tasks;
using InsuranceSales.ViewModels.Product;
using Xunit;

namespace InsuranceSales.UnitTests
{
    public class ProductsViewModelTests
    {
        [Fact]
        public async Task InitializationShouldLoadAvailableProducts()
        {
            // Arrange
            var vm = new ProductListViewModel();

            // Act
            await Task.Delay(1000);

            // Assert
            Assert.NotEmpty(vm.Products);
        }

        [Fact]
        public async Task InitializationShouldSetHeader()
        {
            // Arrange
            var vm = new ProductListViewModel();

            // Act
            await Task.Delay(1000);

            // Assert
            Assert.NotEqual("", vm.Header);
        }
    }
}
