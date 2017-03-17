using System;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class SpecialWorkHour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan OpenHour { get; set; }

        [Required]
        public TimeSpan CloseHour { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}