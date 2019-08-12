using System;
using InsuranceSales.ViewModels;
using MvvmHelpers;
using Xamarin.Forms;

namespace InsuranceSales.Views
{
    public abstract class ContentPageBase<T> : ContentPage where T : ViewModelBase
    {
        private bool _isInitialized;

        protected virtual T ViewModel => BindingContext as T;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_isInitialized)
            {
                ViewModel.InitializeAsync();
                _isInitialized = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}