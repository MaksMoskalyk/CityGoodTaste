using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Menu
    {


        [Key]
        public int Id { get; set; }

        [Display(Name = "SubMenuName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "MealGroups", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<MealGroup> MealGroups { get; set; }

        [Display(Name = "RestaurantName", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
        [Display(Name = "IsShowMenu", ResourceType = typeof(Resources.Resource))]
        public bool IsShow { get; set; }
    }
}