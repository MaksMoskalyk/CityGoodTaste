using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantFeature
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public byte[] Icon { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

        
    }
}