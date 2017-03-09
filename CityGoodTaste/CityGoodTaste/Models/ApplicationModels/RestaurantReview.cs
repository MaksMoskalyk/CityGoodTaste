using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste
{
    public class RestaurantReview
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ReviewDate", ResourceType = typeof(Resources.Resource))]
        public DateTime Date { get; set; }

        [Display(Name = "ReviewText", ResourceType = typeof(Resources.Resource))]
        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "User", ResourceType = typeof(Resources.Resource))]
        public virtual User User { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
    }
}