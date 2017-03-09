using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class Cuisine
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CousineName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Restaurants", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Restaurant> Restaurants { get; set; }

        [Display(Name = "Users", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<User> Users { get; set; }
    }
}