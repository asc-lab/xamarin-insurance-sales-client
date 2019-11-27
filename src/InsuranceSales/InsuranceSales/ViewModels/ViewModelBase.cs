using InsuranceSales.Interfaces;
using MvvmHelpers;
using System.Threading.Tasks;

namespace InsuranceSales.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        protected readonly IAuthenticationService AuthenticationService;

        public ViewModelBase(IAuthenticationService authenticationService) =>
            AuthenticationService = authenticationService;

        public virtual async Task InitializeAsync() => await Task.CompletedTask;
    }
}
