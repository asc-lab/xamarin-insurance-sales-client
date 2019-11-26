using InsuranceSales.Interfaces;
using InsuranceSales.Services;
using Xamarin.Forms;

namespace InsuranceSales
{
    public partial class App
    {
        private static NetworkManager _networkManager;
        protected internal static NetworkManager NetworkManager => _networkManager ?? (_networkManager = new NetworkManager());

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            if (AppSettings.UseMockAuthentication)
                DependencyService.Register<IAuthenticationService, MockAuthenticationService>();

            // TODO: Remove
            /*if (AppSettings.UseMockDataService)
                DependencyService.Register<IProductsService, MockProductsService>();*/

            DependencyService.Register<IDialogService, DialogService>();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
