using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Phone
    {
        public Phone() { }

        public Phone(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }
  
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}