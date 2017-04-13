using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantFeature
    {
        public RestaurantFeature() { }

        public RestaurantFeature(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public byte[] Icon { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }       
    }
}