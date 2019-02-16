using SQLite;

namespace XamarinMapsApp.Models
{
    [Table("Friends")]
    public class FavoritePlace
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string NamePlace { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FormattedAddress { get; set; }
        public string PathPhoto { get; set; }
        public string Discription { get; set; }
    }
}