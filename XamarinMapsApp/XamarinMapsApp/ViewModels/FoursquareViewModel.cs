using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using XamarinForms.Models;

namespace XamarinForms.ViewModels
{
    public class FoursquareViewModel : INotifyPropertyChanged
    {

        // use this link to get an api_key : https://foursquare.com/developers/register/&limit=1
        private const string ClientId = "MZ5G10FEW2SKZPMETDOT1BFCP2Q2RFY5D4UXOBSGUV32RZDO";
        private const string ClientSecret = "E1DLCBVYAQWTHLLNTQO3WXZYCZ0M2BEY03AC0ZLOFOS4A5C5";
        private const string v = "20190208";
        private const string venueId = "4d4b7105d754a06374d81259";
        public string Lon = "0.0";
        public string Lat = "0.0";
        //private const string ClientId = "0VI3W11FN5LCQTIPASLFUUWSAX515QF4TTY1L4VAKWPPB4IO";
        //private const string ClientSecret = "M4ALRFCDHONLXSSULN23EDKDJG14WD2GC00OCADD5KKYAUFO";
        //private const string v = "20160611";
        //private const string venueId = "40a55d80f964a52020f31ee3";

        // doc : https://developer.foursquare.com/docs/venues/search
        //private string apiUrlForVenues = $"https://api.foursquare.com/v2/venues/explore?ll={Lon},{Lat}&client_id={ClientId}&client_secret={ClientSecret}&v={v}&radius=1000&venuePhotos=1";

        private string apiUrlForVenues = $"";

        private FoursquareVenues _foursquareVenues;

        public FoursquareVenues FoursquareVenues
        {
            get { return _foursquareVenues; }
            set
            {
                _foursquareVenues = value;
                OnPropertyChanged();
            }
        }

        public FoursquareViewModel()
        {
            InitDataAsync();
        }

        public async Task InitDataAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 1000;

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return;
                }

                var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000), null, false);


                //Position position = null;
                //var locator = CrossGeolocator.Current;
                //locator.DesiredAccuracy = 100;
                ////position = await locator.GetLastKnownLocationAsync();
                ////var locator = CrossGeolocator.Current;
                //locator.DesiredAccuracy = 1000;

                ////position = await locator.GetLastKnownLocationAsync();

                //if (position != null)
                //{
                //    //got a cahched position, so let's use it.
                //    return;
                //}

                //if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                //{
                //    //not available or enabled
                //    return;
                //}

                //position = await locator.GetPositionAsync(TimeSpan.FromSeconds(60), null, true);


                //position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

                //position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                Lon = Math.Round(position.Longitude, 6).ToString();
                Lat = Math.Round(position.Latitude, 6).ToString();
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            apiUrlForVenues = $"https://api.foursquare.com/v2/venues/explore?ll={Lon},{Lat}&client_id={ClientId}&client_secret={ClientSecret}&v={v}&radius=3000&venuePhotos=1";
            //apiUrlForVenues = $"https://api.foursquare.com/v2/venues/explore?ll=49.166126,55.789912&client_id={ClientId}&client_secret={ClientSecret}&v={v}&radius=3000&venuePhotos=1";
            var httpClient = new HttpClient();


            var json = await httpClient.GetStringAsync(apiUrlForVenues);
            
            FoursquareVenues = JsonConvert.DeserializeObject<FoursquareVenues>(json);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}