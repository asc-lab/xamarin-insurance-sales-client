using InsuranceSales.ViewModels.Policy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Policy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyOfferFormPage
    {
        public PolicyOfferFormPage() => InitializeComponent();

        private void PolicyFromPicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            if (BindingContext is PolicyOfferFormViewModel vm)
                vm.ProductFrom = e.NewDate;
        }

        private void PolicyToPicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            if (BindingContext is PolicyOfferFormViewModel vm)
                vm.ProductTo = e.NewDate;
        }
    }
}