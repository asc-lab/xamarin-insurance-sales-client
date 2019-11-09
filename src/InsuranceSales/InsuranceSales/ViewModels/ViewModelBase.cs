using System.Threading.Tasks;
using InsuranceSales.Interfaces;
using InsuranceSales.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        protected IAuthenticationService AuthenticationService => DependencyService.Get<IAuthenticationService>();

        public virtual Task InitializeAsync() => Task.CompletedTask;
    }
}
