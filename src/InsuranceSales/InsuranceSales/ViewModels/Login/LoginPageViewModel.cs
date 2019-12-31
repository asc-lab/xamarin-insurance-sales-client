using InsuranceSales.Interfaces;
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

        public bool IsSignedIn { get; set; }
        #endregion

        #region COMMANDS
        private ICommand _signInCommand;
        public ICommand SignInCommand => _signInCommand ??= new Command(async () => await SignInAction());
        #endregion

        public LoginPageViewModel(IAuthenticationService authenticationService, IDialogService dialogService)
            : base(authenticationService)
        {
            _dialogService = dialogService;
        }

        public LoginPageViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        {
            _dialogService = DependencyService.Resolve<IDialogService>();
        }

        private async Task SignInAction()
        {
            //if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            //{
            //    await _dialogService.DisplayCustomAlertAsync(Labels.SignIn, Messages.UsernameOrPasswordCannotBeEmpty, Labels.Ok);
            //    return;
            //}
            try
            {
                //await AuthenticationService.AuthenticateAsync(new UserCredentialsModel { Username = _username, Password = _password });
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
