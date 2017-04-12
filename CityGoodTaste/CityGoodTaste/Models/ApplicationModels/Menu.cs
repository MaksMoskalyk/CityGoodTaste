using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Menu
    {
        public Menu() { }

        public Menu(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }
       
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public bool IsShow { get; set; }


        public virtual ICollection<MealGroup> MealGroups { get; set; }

        public virtual Restaurant Restaurant { get; set; }        
    }
}