using InsuranceSales.Interfaces;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class PolicyDetailsViewModel : ViewModelBase
    {
        public PolicyDetailsViewModel()
        : base(DependencyService.Resolve<IAuthenticationService>())
        { }
    }
}
