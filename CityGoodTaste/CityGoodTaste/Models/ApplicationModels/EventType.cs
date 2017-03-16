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

        [Display(Name = "EventTypeName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Icon", ResourceType = typeof(Resources.Resource))]
        public byte[] Icon { get; set; }

        [Display(Name = "RestaurantEvent", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<RestaurantEvent> RestaurantEvents { get; set; }
    }
}