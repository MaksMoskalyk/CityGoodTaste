using System;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class WorkHour
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "OpenHourName", ResourceType = typeof(Resources.Resource))]
        public TimeSpan OpenHour { get; set; }

        [Display(Name = "CloseHourName", ResourceType = typeof(Resources.Resource))]
        public TimeSpan CloseHour { get; set; }

        [Display(Name = "Restaurant", ResourceType = typeof(Resources.Resource))]
        public virtual Restaurant Restaurant { get; set; }
    }
}