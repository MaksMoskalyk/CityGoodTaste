using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantFeature
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "RestaurantFeatureName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Icon", ResourceType = typeof(Resources.Resource))]
        public byte[] Icon { get; set; }

        [Display(Name = "Restaurants", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}