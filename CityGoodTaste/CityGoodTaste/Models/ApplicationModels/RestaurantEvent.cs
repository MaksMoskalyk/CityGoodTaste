using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CityGoodTaste.Models
{
    public class RestaurantEvent
    {
        public RestaurantEvent()
        {

        }
        public RestaurantEvent(string name, string description, DateTime startDate, DateTime endDate, Restaurant restaurant)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Restaurant = restaurant;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<EventType> EventTypes { get; set; }
    }
}