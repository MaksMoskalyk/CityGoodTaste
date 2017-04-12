using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class City
    {
        public City() {}

        public City(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }

        public virtual Country Country { get; set; }
    }
}