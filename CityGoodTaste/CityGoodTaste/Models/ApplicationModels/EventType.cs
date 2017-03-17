using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public byte[] Icon { get; set; }


        public virtual ICollection<RestaurantEvent> RestaurantEvents { get; set; }
    }
}