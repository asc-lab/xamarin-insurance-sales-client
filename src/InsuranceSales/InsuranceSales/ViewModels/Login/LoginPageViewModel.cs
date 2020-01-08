using InsuranceSales.i18n;
using InsuranceSales.Interfaces;
using InsuranceSales.Models;
using InsuranceSales.Resources;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Login
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region SERVICES
        private readonly IDialogService _dialogService;
        #endregion

        #region PROPS
        private string _username;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        private bool _isSignedIn;
        public bool IsSignedIn { get => _isSignedIn; set => SetProperty(ref _isSignedIn, value); }
        #endregion

        #region COMMANDS
        private ICommand _signInCommand;
        public ICommand SignInCommand => _signInCommand ??= new Command(async () => await SignInAction());
        #endregion

        public LoginPageViewModel(
            IAuthenticationService authenticationService,
            IDialogService dialogService
            ) : base(authenticationService)
        {
            _dialogService = dialogService;
        }

        public LoginPageViewModel() : this(
            DependencyService.Resolve<IAuthenticationService>(),
            DependencyService.Resolve<IDialogService>())
        { }

        private async Task SignInAction()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await _dialogService.DisplayCustomAlertAsync(Labels.SignIn, Messages.UsernameOrPasswordCannotBeEmpty, Labels.Ok);
                return;
            }
            try
            {
                var credentials = new UserCredentialsModel { Username = _username, Password = _password };
                var isAuthenticated = await AuthenticationService.AuthenticateAsync(credentials);
                IsSignedIn = isAuthenticated;

                if (!isAuthenticated)
                    return;

                await Shell.Current.Navigation.PopModalAsync();

                MessagingCenter.Send(this, MessageKeys.AUTH_MSG);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
