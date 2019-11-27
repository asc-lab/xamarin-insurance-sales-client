using InsuranceSales.ViewModels;
using Xamarin.Forms;

namespace InsuranceSales.Views
{
    public abstract class ContentPageBase<T> : ContentPage where T : ViewModelBase
    {
        private bool _isInitialized;

        protected virtual T ViewModel => BindingContext as T;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_isInitialized)
                return;

            await ViewModel.InitializeAsync();
            _isInitialized = true;
        }
    }
}