using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Currency
    {
        public Currency() { }

        public Currency(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        [Required]
        public string Sing { get; set; }
        
        ICollection<Meal> Meal { get; set; }
    }
}