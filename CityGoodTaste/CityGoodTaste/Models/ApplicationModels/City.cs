using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public virtual Country Country { get; set; }
    }
}