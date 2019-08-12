using InsuranceSales.Interfaces;
using InsuranceSales.Services;
using Xamarin.Forms;

namespace InsuranceSales
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DependencyService.Register<IAuthenticationService, AuthenticationService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
