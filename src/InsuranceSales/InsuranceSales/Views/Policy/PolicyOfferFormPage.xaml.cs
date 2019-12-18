using System;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Views.Policy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyOfferFormPage
    {
        public PolicyOfferFormPage() => InitializeComponent();

        private void Order_OnClicked(object sender, EventArgs e)
        {
            var entryAnswers = DynamicEntries?.GetAnswers();
            if (ViewModel.SendNewOfferCommand.CanExecute(entryAnswers))
                ViewModel?.SendNewOfferCommand?.Execute(entryAnswers);
        }
    }
}