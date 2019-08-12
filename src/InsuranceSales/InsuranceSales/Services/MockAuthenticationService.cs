using System;
using System.Threading.Tasks;
using InsuranceSales.Interfaces;
using InsuranceSales.Models;

namespace InsuranceSales.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private bool _isAuthenticated;

        public Task AuthenticateAsync(UserCredentialsModel userCredentials)
        {
            // TODO: Implement
            if (userCredentials.Username == "admin" && userCredentials.Password == "admin")
                _isAuthenticated = true;

            return Task.FromResult(true);
        }

        public bool IsAuthenticated()
        {
            // TODO: Implement
            return _isAuthenticated;
        }
    }
}
