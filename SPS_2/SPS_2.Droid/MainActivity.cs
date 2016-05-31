using System;

using Android.App;
using Android.Content.PM;
using Xamarin.Forms;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SPS_2.Droid
{
    [Activity(Label = "SPS_2", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

