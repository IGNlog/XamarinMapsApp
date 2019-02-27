using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Plugin.Permissions;
using Android.Support.V4.Content;

namespace XamarinMapsApp.Droid
{
    [Activity(Label = "XamarinMapsApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation,
                    Manifest.Permission.AccessFineLocation, Manifest.Permission.Camera,
                    Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage}, 0);

        }

        protected override void OnStart()
        {
            base.OnStart();
            if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)||
                (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != (int)Permission.Granted)||
                (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted) ||
                (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted))
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation,
                    Manifest.Permission.AccessFineLocation, Manifest.Permission.Camera,
                    Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage}, 0);
                //RequestPermissions(new string[] { Manifest.Permission.Camera, }, 0);
                //RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
            }

            //if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != (int)Permission.Granted))
            //{
            //    RequestPermissions(new string[] { Manifest.Permission.Camera, }, 0);
            //    RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
            //}

            //if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted)||
            //    (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted))
            //{
            //    RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
            //}
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        //{
        //    Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}