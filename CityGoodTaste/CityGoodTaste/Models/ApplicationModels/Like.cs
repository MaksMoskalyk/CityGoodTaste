using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}