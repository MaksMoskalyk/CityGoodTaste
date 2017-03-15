using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste
{

    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "RestaurantName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "RestaurantAddress", ResourceType = typeof(Resources.Resource))]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "ZipCode", ResourceType = typeof(Resources.Resource))]
        public int ZipCode { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resource))]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        [Display(Name = "AverageCheck", ResourceType = typeof(Resources.Resource))]
        public int AverageCheck { get; set; }

        [Display(Name = "InformationAboutRestaurant", ResourceType = typeof(Resources.Resource))]
        [Column(TypeName = "ntext")]
        public string InformationAbout { get; set; }

        [Display(Name = "WorkHours", ResourceType = typeof(Resources.Resource))]
        public ICollection<WorkHour> WorkHours { get; set; }

        [Display(Name = "SpecialWorkHours", ResourceType = typeof(Resources.Resource))]
        public ICollection<SpecialWorkHour> SpecialWorkHours { get; set; }

        [Display(Name = "Photos", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Photo> Photos { get; set; }

        [Display(Name = "RestaurantSchemas", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<RestaurantSchema> RestaurantSchemas { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Resource))]
        public virtual City City { get; set; }

        [Display(Name = "Cuisines", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Cuisine> Cuisines { get; set; }

        [Display(Name = "Floors", ResourceType = typeof(Resources.Resource))]
        public int Floors { get; set; }

        [Display(Name = "Likes", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Like> Likes { get; set; }

        [Display(Name = "RestaurantsGroup", ResourceType = typeof(Resources.Resource))]
        public virtual RestaurantsGroup RestaurantGroup { get; set; }

        [Display(Name = "RestaurantFeatures", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<RestaurantFeature> RestaurantFeatures { get; set; }

        [Display(Name = "Reviews", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<RestaurantReview> Reviews { get; set; }

        [Display(Name = "Menu", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Menu> Menu { get; set; }

        [Display(Name = "Map", ResourceType = typeof(Resources.Resource))]
        public Map Map { get; set; }

        [Display(Name = "RestaurantEvent", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<RestaurantEvent> RestaurantEvent { get; set; }
    }
}