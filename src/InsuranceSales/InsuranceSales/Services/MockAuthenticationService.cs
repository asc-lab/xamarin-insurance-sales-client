using InsuranceSales.Interfaces;
using InsuranceSales.Models;
using System.Threading.Tasks;

namespace InsuranceSales.Services
{
    /// <summary>
    /// TODO: Implement Akavache's SecureStorage
    /// </summary>
    public class MockAuthenticationService : IAuthenticationService
    {
        private bool _isAuthenticated;

        public Task<bool> AuthenticateAsync(UserCredentialsModel userCredentials)
        {
            // TODO: Implement
            if (userCredentials?.Username == "admin" && userCredentials.Password == "admin")
                _isAuthenticated = true;

            return Task.FromResult(_isAuthenticated);
        }

        public bool IsAuthenticated()
        {
            // TODO: Implement
            return _isAuthenticated;
        }
    }
}
