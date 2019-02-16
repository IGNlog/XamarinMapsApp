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
	public partial class FavoritePlacesPage : ContentPage
	{
		public FavoritePlacesPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            favoritePlacesList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FavoritePlace selectedFavoritePlace = (FavoritePlace)e.SelectedItem;
            FavoritePlacePage favoritePlacePage = new FavoritePlacePage();
            favoritePlacePage.BindingContext = selectedFavoritePlace;
            await Navigation.PushAsync(favoritePlacePage);
        }

        // обработка нажатия кнопки добавления
        private async void CreateFavoritePlace(object sender, EventArgs e)
        {
            FavoritePlace favoritePlace = new FavoritePlace();
            FavoritePlacePage favoritePlacePage = new FavoritePlacePage();
            favoritePlacePage.BindingContext = favoritePlace;
            await Navigation.PushAsync(favoritePlacePage);
        }
    }
}