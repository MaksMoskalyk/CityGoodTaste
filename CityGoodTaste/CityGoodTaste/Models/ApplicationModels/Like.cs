using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User", ResourceType = typeof(Resources.Resource))]
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
    }
}