using InsuranceSales.ViewModels;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Policy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyDetailsPage : ContentPageBase<PolicyDetailsViewModel>
    {
        public PolicyDetailsPage() => InitializeComponent();
    }
}