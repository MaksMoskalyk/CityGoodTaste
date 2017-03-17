using System;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class WorkHour
    {
        [Key]
        public int Id { get; set; }

        public TimeSpan OpenHour { get; set; }

        public TimeSpan CloseHour { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}