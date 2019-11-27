using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace InsuranceSales.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            // Initialize Material Design
            FormsMaterial.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
