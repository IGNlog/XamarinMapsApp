using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.ViewModels;
using XamarinForms.Views;
using XamarinMapsApp.Services;
using XamarinMapsApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinMapsApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "favorite_place.db";
        public static FavoritePlaceRepository database;
        public static FavoritePlaceRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new FavoritePlaceRepository(DATABASE_NAME);
                }
                return database;
            }
        }


        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new ContentPage
        //    {
        //        Content = new ActivityIndicator()
        //        {
        //            IsRunning = true,
        //            IsEnabled = true

        //        }
        //    };
        //}

        //protected override async void OnStart()
        //{
        //    var foursquareViewModel = new FoursquareViewModel();

        //    await foursquareViewModel.InitDataAsync();

        //    MainPage = new TabbedPage
        //    {
        //        Children =
        //        {
        //            new MapPage(foursquareViewModel),
        //            new FoursquareViewPage(foursquareViewModel)
        //        }

        //    };
        //    // Handle when your app starts
        //}

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }

        protected override async void OnStart()
        {

            //MapPage = new StartPage();

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
