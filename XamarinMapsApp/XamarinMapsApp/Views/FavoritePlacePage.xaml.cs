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
    }
}