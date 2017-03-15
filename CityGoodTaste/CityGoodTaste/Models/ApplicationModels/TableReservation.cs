using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class TableReservation
    {
        [Key]
        public int Id { get; set; }

        public virtual Table Table { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}