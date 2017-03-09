using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class RestaurantSchema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "RestaurantSchemaName", ResourceType = typeof(Resources.Resource))]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }

        [Display(Name = "Tables", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Table> Tables { get; set; }

        [Display(Name = "SmokingZone", ResourceType = typeof(Resources.Resource))]
        public bool SmokingZone { get; set; }

        [Display(Name = "InDoor", ResourceType = typeof(Resources.Resource))]
        public bool InDoor { get; set; }
    }
}