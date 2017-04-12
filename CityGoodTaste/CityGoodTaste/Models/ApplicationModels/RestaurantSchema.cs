using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class RestaurantSchema
    {
        public RestaurantSchema() { }

        public RestaurantSchema(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
       
        public bool SmokingZone { get; set; }

        public bool InDoor { get; set; }

        public int XLength { get; set; }

        public int YLength { get; set; }


        public virtual Restaurant Restaurant { get; set; }

        public virtual IList<Table> Tables { get; set; }
    }
}