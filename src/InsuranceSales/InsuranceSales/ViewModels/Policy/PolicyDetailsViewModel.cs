using InsuranceSales.Interfaces;
using System;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Policy
{
    public class PolicyDetailsViewModel : ViewModelBase //! TODO
    {
        #region PROPS
        public string PolicyNumber { get; set; }
        public DateTimeOffset PolicyStartDate { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }
        public string ProductCode { get; set; }
        public string PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
        #endregion

        public PolicyDetailsViewModel()
        : base(DependencyService.Resolve<IAuthenticationService>())
        { }
    }
}
