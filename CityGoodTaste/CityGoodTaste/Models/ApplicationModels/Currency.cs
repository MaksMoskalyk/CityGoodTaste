using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        [Required]
        public string sing { get; set; }
        
        ICollection<Meal> Meal { get; set; }
    }
}