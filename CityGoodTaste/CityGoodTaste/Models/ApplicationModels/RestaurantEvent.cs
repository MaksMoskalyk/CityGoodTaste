using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste.Models
{
    public class RestaurantEvent
    {
        private string v1;
        private string v2;
        private DateTime dateTime;
        private Restaurant r;

        public RestaurantEvent(string name, string description, DateTime startDate, DateTime endDate, Restaurant restaurant)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Restaurant = restaurant;
        }

        public RestaurantEvent(string v1, string v2, DateTime dateTime, Restaurant r)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.dateTime = dateTime;
            this.r = r;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "EventName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "EventDescription", ResourceType = typeof(Resources.Resource))]
        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "EventStartDate", ResourceType = typeof(Resources.Resource))]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "EventEndDate", ResourceType = typeof(Resources.Resource))]
        [Required]
        public DateTime EndDate { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
    }
}