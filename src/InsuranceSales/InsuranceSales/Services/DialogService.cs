using InsuranceSales.i18n;
using InsuranceSales.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.Services
{
    public class DialogService : IDialogService
    {
        private static Page MainPage => Application.Current.MainPage;

        public async Task DisplayInfoAlertAsync(string message) =>
            await MainPage.DisplayAlert(Labels.Info, message, Labels.Ok);

        public async Task DisplayErrorAlertAsync(string message) =>
            await MainPage.DisplayAlert(Labels.Error, message, Labels.Ok);

        public async Task DisplayCustomAlertAsync(string title, string message) =>
            await MainPage.DisplayAlert(title, message, Labels.Ok);

        public async Task DisplayCustomAlertAsync(string title, string message, string confirm) =>
            await MainPage.DisplayAlert(title, message, confirm);

        public async Task<bool> DisplayConfirmationAlertAsync(string title, string message) =>
            await MainPage.DisplayAlert(title, message, Labels.Confirm, Labels.Cancel);

        public async Task<bool> DisplayConfirmationAlertAsync(string title, string message, string accept, string cancel) =>
            await MainPage.DisplayAlert(title, message, accept, cancel);
    }
}
