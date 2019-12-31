using InsuranceSales.Models;
using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated();
        Task AuthenticateAsync(UserCredentialsModel userCredentials);
    }
}
