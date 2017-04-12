using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        public int Seats { get; set; }

        public virtual RestaurantSchema RestaurantSchema { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public virtual IList<TableReservation> TableReservation { get; set; }
    }
}