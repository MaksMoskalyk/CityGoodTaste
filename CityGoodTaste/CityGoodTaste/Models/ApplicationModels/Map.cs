using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Map
    {
        public Map()
        {
        }
        public Map(double latitude, double longitude, int zoom)
        {
            Latitude = latitude;
            Longitude = longitude;
            Zoom = zoom;
        }

        [Key]
        public int id { get; set; }


        public double Latitude { get; set; }


        public double Longitude { get; set; }


        public int Zoom { get; set; }
    }
}