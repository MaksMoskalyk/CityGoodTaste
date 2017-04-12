using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantsGroup
    {
        public RestaurantsGroup() { }

        public RestaurantsGroup(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}