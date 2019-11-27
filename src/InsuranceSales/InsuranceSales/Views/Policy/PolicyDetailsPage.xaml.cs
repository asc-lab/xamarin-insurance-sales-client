using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Policy
{
    [QueryProperty(nameof())]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyDetailsPage
    {
        public PolicyDetailsPage() => InitializeComponent();
    }
}