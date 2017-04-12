using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Administration
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public virtual ICollection<ApplicationUser> Admins { get; set; }
    }
}