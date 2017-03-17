using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        [Key]
        public int Id { get; set; }

        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public virtual ICollection<City> Cities { get; set; }
    }
}