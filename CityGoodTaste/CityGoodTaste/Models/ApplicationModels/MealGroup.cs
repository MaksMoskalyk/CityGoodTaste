using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class MealGroup
    {
        public MealGroup() {}

        public MealGroup(string name)
        {
            Name = name;
        }
        

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public virtual ICollection<Meal> Meals { get; set; }

        public virtual Menu Menu { get; set; }
    }
}