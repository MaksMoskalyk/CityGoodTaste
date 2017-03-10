using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "MealName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "MealGroup", ResourceType = typeof(Resources.Resource))]
        public virtual MealGroup MealGroup { get; set; }

        [Display(Name = "MealDescription", ResourceType = typeof(Resources.Resource))]
        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "MealPrice", ResourceType = typeof(Resources.Resource))]
        public double Price { get; set; }

        [Display(Name = "Cuisine", ResourceType = typeof(Resources.Resource))]
        public virtual Cuisine Cuisine { get; set; }
    }
}