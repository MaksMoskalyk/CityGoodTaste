using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
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

        public int X { get; set; }
        public int Y { get; set; }
    }
}