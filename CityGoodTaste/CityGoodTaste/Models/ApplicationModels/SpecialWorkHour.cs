using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class SpecialWorkHour
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "OpenHourName", ResourceType = typeof(Resources.Resource))]
        [Required]
        public TimeSpan OpenHour { get; set; }

        [Display(Name = "CloseHourName", ResourceType = typeof(Resources.Resource))]
        [Required]
        public TimeSpan CloseHour { get; set; }

        [Display(Name = "WorkDate", ResourceType = typeof(Resources.Resource))]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
    }
}