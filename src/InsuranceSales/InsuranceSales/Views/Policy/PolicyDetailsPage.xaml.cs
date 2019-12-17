using InsuranceSales.ViewModels.Policy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Policy
{
    [QueryProperty(nameof(PolicyDetailsViewModel.PolicyNumber), "policyNumber")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyDetailsPage
    {
        public string PolicyNumber { get => ViewModel.PolicyNumber; set => ViewModel.PolicyNumber = value; }

        public PolicyDetailsPage() => InitializeComponent();
    }
}