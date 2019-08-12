using System.Threading.Tasks;
using InsuranceSales.Models;

namespace InsuranceSales.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated();
        Task AuthenticateAsync(UserCredentialsModel userCredentials);
    }
}
