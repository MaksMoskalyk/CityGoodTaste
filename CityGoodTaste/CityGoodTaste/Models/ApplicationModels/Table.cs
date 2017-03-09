using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        public int Seats { get; set; }

        [Display(Name = "RestaurantSchema", ResourceType = typeof(Resources.Resource))]
        public virtual RestaurantSchema RestaurantSchema { get; set; }

        [Display(Name = "Orders", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}