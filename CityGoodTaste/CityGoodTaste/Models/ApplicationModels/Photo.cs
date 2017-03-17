using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
  
        public string Path { get; set; }

      
        public virtual Restaurant Restaurant { get; set; }
    }
}