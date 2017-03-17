using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantSchema
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Table> Tables { get; set; }

        public bool SmokingZone { get; set; }

        public bool InDoor { get; set; }

        public int XLength { get; set; }
        public int YLength { get; set; }
    }
}