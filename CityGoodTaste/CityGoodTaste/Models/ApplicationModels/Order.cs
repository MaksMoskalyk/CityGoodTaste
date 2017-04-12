using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CityGoodTaste.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }


        public virtual Restaurant Restaurant { get; set; }

        public virtual ApplicationUser User { get; set; }
  
        public virtual ICollection<PriceEntry> PriceEntries { get; set; }
   
        public virtual ICollection<Table> Tables { get; set; }
    }
}