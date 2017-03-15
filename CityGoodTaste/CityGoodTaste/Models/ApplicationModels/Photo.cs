using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "PhotoPath", ResourceType = typeof(Resources.Resource))]
        public string Path { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
    }
}