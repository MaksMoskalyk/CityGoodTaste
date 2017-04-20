using System;
using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class TableReservation
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date {get;set;}
       
        public bool Reserved { get; set; }

        public bool ReservedAndConfirmed { get; set; }

        public bool ConfirmedByAdministration { get; set; }

        public virtual Table Table { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ContactInfoName { get; set; }
        public string ContactInfoPhone { get; set; }
    }
}