using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantsGroup
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "RestarauntGroupName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Restaurants", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}