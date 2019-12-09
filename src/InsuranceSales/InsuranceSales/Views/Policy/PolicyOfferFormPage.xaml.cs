using InsuranceSales.ViewModels.Policy;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Policy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyOfferFormPage
    {
        public PolicyOfferFormPage() => InitializeComponent();

        private void PolicyFromPicker_OnDateSelected(object sender, DateChangedEventArgs e) => ViewModel.ProductFrom = e.NewDate;

        private void PolicyToPicker_OnDateSelected(object sender, DateChangedEventArgs e) => ViewModel.ProductTo = e.NewDate;

        private void Order_OnClicked(object sender, EventArgs e)
        {
            var entryAnswers = DynamicEntries?.GetAnswers();
            ViewModel?.SendNewOffer(entryAnswers);
        }

        // HIDE DYNAMIC ENTRIES
        // SHOW CONTACT DATA ENTRIES
        private void BuyNow_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}