using InsuranceSales.ViewModels;
using Xunit;

namespace InsuranceSales.UnitTests
{
    public class ProductsViewModelTests
    {
        [Fact]
        public void InitializationShouldLoadAvailableProducts()
        {
            // Arrange
            var vm = new ProductsPageViewModel();

            // Act

            // Assert
            Assert.NotEmpty(vm.Products);
        }

        [Fact]
        public void InitializationShouldSetHeader()
        {
            // Arrange
            var vm = new ProductsPageViewModel();

            // Act

            // Assert
            Assert.NotEqual("", vm.Header);
        }
    }
}
