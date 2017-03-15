using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "RestaurantName", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }

        [Display(Name = "User", ResourceType = typeof(Resources.Resource))]
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "OrderDate", ResourceType = typeof(Resources.Resource))]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "PriceEntries", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<PriceEntry> PriceEntries { get; set; }

        [Display(Name = "Tables", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Table> Tables { get; set; }
    }
}