using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

  
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Name { get; set; }

  
        public virtual ApplicationUser User { get; set; }
    }
}