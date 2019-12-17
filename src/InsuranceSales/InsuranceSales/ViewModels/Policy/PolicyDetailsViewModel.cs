using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using InsuranceSales.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Policy
{
    public class PolicyDetailsViewModel : ViewModelBase
    {
        #region SERVICES
        private readonly NetworkManager _networkManager;
        #endregion

        #region PROPS
        private PolicyModel _policy;
        public PolicyModel Policy { get => _policy; set => SetProperty(ref _policy, value); }

        private string _policyNumber;
        public string PolicyNumber { get => _policyNumber; set => SetProperty(ref _policyNumber, value); }

        private DateTimeOffset _startDate;
        public DateTimeOffset StartDate { get => _startDate; set => SetProperty(ref _startDate, value); }

        private DateTimeOffset _endDate;
        public DateTimeOffset EndDate { get => _endDate; set => SetProperty(ref _endDate, value); }

        private string _productCode;
        public string ProductCode { get => _productCode; set => SetProperty(ref _productCode, value); }

        private string _holder;
        public string Holder { get => _holder; set => SetProperty(ref _holder, value); }

        private decimal _premiumAmount;
        public decimal PremiumAmount { get => _premiumAmount; set => SetProperty(ref _premiumAmount, value); }
        #endregion

        /// <summary>
        /// TESTING ONLY
        /// </summary>
        public PolicyDetailsViewModel(
            IAuthenticationService authenticationService,
            NetworkManager networkManager
        ) : base(authenticationService)
        {
            _networkManager = networkManager;
        }

        public PolicyDetailsViewModel()
        : this(
            DependencyService.Resolve<IAuthenticationService>(),
            App.NetworkManager)
        { }

        public override Task InitializeAsync()
        {
            var policy = _networkManager.GetPolicyByNumberAsync(PolicyNumber);
            Policy = policy;
            PolicyNumber = policy.Number;


            return base.InitializeAsync();
        }
    }
}
