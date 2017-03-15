using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CityGoodTaste.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public virtual Table Table { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}