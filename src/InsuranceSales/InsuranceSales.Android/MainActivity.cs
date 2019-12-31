using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Essentials = Xamarin.Essentials.Platform;

namespace InsuranceSales.Droid
{
    [Activity(Label = "InsuranceSales",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Essentials.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            CachedImageRenderer.Init(true);

            Window.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Essentials.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}