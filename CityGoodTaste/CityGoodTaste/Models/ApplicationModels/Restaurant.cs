using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        public int ZipCode { get; set; }

        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        public int AverageCheck { get; set; }

        [Column(TypeName = "ntext")]
        public string InformationAbout { get; set; }

        public ICollection<WorkHour> WorkHours { get; set; }

        public ICollection<SpecialWorkHour> SpecialWorkHours { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<RestaurantSchema> RestaurantSchemas { get; set; }

        public virtual City City { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }

        public int Floors { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual RestaurantsGroup RestaurantGroup { get; set; }

        public virtual ICollection<RestaurantFeature> RestaurantFeatures { get; set; }

        public virtual ICollection<RestaurantReview> Reviews { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }

        public Map Map { get; set; }

        public virtual ICollection<RestaurantEvent> RestaurantEvent { get; set; }
    }
}