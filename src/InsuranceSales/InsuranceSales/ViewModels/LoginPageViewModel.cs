using System;
using InsuranceSales.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _username;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public bool IsSignedIn { get; set; }

        private ICommand _signInCommand;
        public ICommand SignInCommand => _signInCommand ?? (_signInCommand = new Command(async () =>  await SignInAction()));

        private async Task SignInAction()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Sign In", "Username or password cannot be empty.", "Ok");
                return;
            }

            try
            {
                await AuthenticationService.AuthenticateAsync(new UserCredentialsModel { Username = _username, Password = _password });
                await Application.Current.MainPage.Navigation.PopModalAsync();

                MessagingCenter.Send(this, "AUTH_MSG");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
