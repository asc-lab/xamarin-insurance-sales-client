using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string username;
        private string password;

        private ICommand _signInCommand;

        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public bool IsSignIn { get; set; }

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
                await AuthenticationService.AuthenticateAsync(new Models.UserCredentialsModel { Username = username, Password = password });
                await Application.Current.MainPage.Navigation.PopModalAsync();

                MessagingCenter.Send(this, "AUTH_MSG");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
