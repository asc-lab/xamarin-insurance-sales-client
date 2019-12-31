using InsuranceSales.ViewModels.Login;
using Xunit;

namespace InsuranceSales.UnitTests
{
    public class LoginViewModelTests
    {
        [Fact]
        public void UserCanSignIn()
        {
            // Arrange
            string username = "admin";
            string password = "admin";
            var vm = new LoginPageViewModel();

            // Act
            vm.Username = username;
            vm.Password = password;
            vm.SignInCommand.Execute(null);

            // Assert
            Assert.True(vm.IsSignedIn);
        }
    }
}
