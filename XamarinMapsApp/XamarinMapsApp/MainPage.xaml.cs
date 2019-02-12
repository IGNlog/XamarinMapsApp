using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinForms.ViewModels;

namespace XamarinMapsApp
{
    public partial class MainPage : ContentPage
    {

        private FoursquareViewModel _foursquareViewModel;
        private Pin selectedPin;
        private double Lon;
        private double Lat;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(FoursquareViewModel foursquareViewModel)
        {
            InitializeComponent();

            _foursquareViewModel = foursquareViewModel;

            Lon = Convert.ToDouble(_foursquareViewModel.Lon);
            Lat = Convert.ToDouble(_foursquareViewModel.Lat);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //try
            //{
            //    var locator = CrossGeolocator.Current;
            //    locator.DesiredAccuracy = 50;

            //    var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            //    //var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            //    //var location = await Geolocation.GetLocationAsync(request);

            //    //if (location != null)
            //    //{
            //    //    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    // Unable to get location
            //}

            //MainMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //        new Position(55.792409, 49.122342),
            //    Distance.FromMeters(2000)));

            MainMap.MoveToRegion(
               MapSpan.FromCenterAndRadius(
                   new Position(Lon, Lat),
               Distance.FromMeters(2000)));

            var items = _foursquareViewModel.FoursquareVenues.Response.Groups[0].Items;

            foreach (var item in items)
            {
                var pin = new Pin
                {
                    Position = new Position(
                                    item.Venue.Location.Lat,
                                    item.Venue.Location.Lng),
                    Label = item.Venue.Name,
                    Address = item.Venue.Location.FormattedAddress[0]
                };

                pin.Clicked += Pin_Clicked;
                MainMap.Pins.Add(pin);
            }
        }

        private void Pin_Clicked(object sender, EventArgs eventArgs)
        {
            selectedPin = sender as Pin;

            PlaceStackLayout.BindingContext = _foursquareViewModel.
                FoursquareVenues.Response.Groups[0].
                Items.First(item => item.Venue.Name == selectedPin?.Label);
            //DisplayAlert(selectedPin?.Label, selectedPin?.Address, "Ok");
        }

        private void GetDirections_Clicked(object sender, EventArgs e)
        {
            //CrossExternalMaps.Current.NavigateTo(
            //    selectedPin.Label,
            //    selectedPin.Position.Latitude,
            //    selectedPin.Position.Longitude,
            //    NavigationType.Driving);
        }
    }
}
