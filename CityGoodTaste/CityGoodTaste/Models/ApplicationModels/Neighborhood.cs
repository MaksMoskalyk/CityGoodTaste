using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class Neighborhood
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}