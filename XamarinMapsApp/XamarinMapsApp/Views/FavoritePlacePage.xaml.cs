using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMapsApp.Models;

namespace XamarinMapsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePlacePage : ContentPage
    {
        //public ImageSource ImageSourcePhoto;

        public FavoritePlacePage()
        {
            InitializeComponent();
        }

        private void SaveFavoritePlace(object sender, EventArgs e)
        {
            var friend = (FavoritePlace)BindingContext;
            if (!String.IsNullOrEmpty(friend.NamePlace))
            {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }

        private void DeleteFavoritePlace(object sender, EventArgs e)
        {
            var friend = (FavoritePlace)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void takePhotoBtn_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Sample",
                    Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
                });

                if (file == null)
                    return;

                img.Source = ImageSource.FromFile(file.Path);
                //ImageSourcePhoto = ImageSource.FromFile(file.Path);
            }
        }

        private async void getPhotoBtn_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                img.Source = ImageSource.FromFile(photo.Path);
            }
        }
    }
}