using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class PriceEntry
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Meal", ResourceType = typeof(Resources.Resource))]
        public virtual Meal Meal { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        public double Price { get; set; }
        [Display(Name = "Сurrency", ResourceType = typeof(Resources.Resource))]
        public string Сurrency{ get; set; }
    }
}