using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class PriceEntry
    {
        [Key]
        public int Id { get; set; }

        public virtual Meal Meal { get; set; }

        public double Price { get; set; }
   
        public string Сurrency{ get; set; }
    }
}