using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public virtual ICollection<MealGroup> MealGroups { get; set; }


        public virtual Restaurant Restaurant { get; set; }

        public bool IsShow { get; set; }
    }
}