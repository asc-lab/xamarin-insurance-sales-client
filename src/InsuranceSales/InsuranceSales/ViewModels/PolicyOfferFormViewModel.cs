using InsuranceSales.Interfaces;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class PolicyOfferFormViewModel : ViewModelBase
    {
        public PolicyOfferFormViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        { }
    }
}
