using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class MealGroup
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "MealGroupName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Meals", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Meal> Meals { get; set; }

        [Display(Name = "MealsMenu", ResourceType = typeof(Resources.Resource))]
        public virtual Menu Menu { get; set; }
    }
}