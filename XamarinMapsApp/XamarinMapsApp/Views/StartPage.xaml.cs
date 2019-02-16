using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.ViewModels;
using XamarinForms.Views;

namespace XamarinMapsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;
            if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
            {
                //not available or enabled
                return;
            }
            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(30000), null, false);

            LongitudeLabel.Text = position.Longitude.ToString();
            LatitudeLabel.Text = position.Latitude.ToString();

            await Task.Delay(1000);

            FoursquareViewModel foursquareViewModel = new FoursquareViewModel(position);
            await foursquareViewModel.InitDataAsync();

            //await Navigation.PushAsync(new MapPage(foursquareViewModel));
            await Navigation.PushAsync(new TabbedPage
            {
                Children =
                {
                    new MapPage(foursquareViewModel),
                    new FoursquareViewPage(foursquareViewModel),
                    new FavoritePlacesPage()
                }
            });
            //MapPage = new 
        }
    }
}