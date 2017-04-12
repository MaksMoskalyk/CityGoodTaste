using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class EventType
    {
        public EventType() { }

        public EventType(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public byte[] Icon { get; set; }

        public virtual ICollection<RestaurantEvent> RestaurantEvents { get; set; }
    }
}