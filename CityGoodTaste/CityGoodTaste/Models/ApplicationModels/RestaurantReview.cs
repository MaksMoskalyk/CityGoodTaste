using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste.Models
{
    public class RestaurantReview
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public int FoodRank { get; set; }
        public int AmbienceRank { get; set; }
        public int ServiceRank { get; set; }
        public double Rank { get; set; }
    }
}