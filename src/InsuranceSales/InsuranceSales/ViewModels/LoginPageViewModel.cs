using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string username;
        private string password;

        private ICommand _signInCommand;

        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public bool IsSignIn { get; set; }

        public ICommand SignInCommand => _signInCommand ?? (_signInCommand = new Command(SignInAction));

        public LoginPageViewModel()
        {
        }

        private void SignInAction()
        {
            IsSignIn = true;
        }
    }
}
