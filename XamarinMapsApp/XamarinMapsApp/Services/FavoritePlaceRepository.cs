using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinMapsApp.Models;

namespace XamarinMapsApp.Services
{
    public class FavoritePlaceRepository
    {
        SQLiteConnection database;
        public FavoritePlaceRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<FavoritePlace>();
        }

        public IEnumerable<FavoritePlace> GetItems()
        {
            return (from i in database.Table<FavoritePlace>() select i).ToList();
        }

        public FavoritePlace GetItem(int id)
        {
            return database.Get<FavoritePlace>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<FavoritePlace>(id);
        }
        public int SaveItem(FavoritePlace item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
