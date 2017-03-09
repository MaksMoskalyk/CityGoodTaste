using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CityName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(Resources.Resource))]
        public virtual Country Country { get; set; }
    }
}