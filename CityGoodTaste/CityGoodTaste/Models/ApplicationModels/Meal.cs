﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityGoodTaste.Models
{
    public class Meal
    {
        public Meal() { }

        public Meal(string name)
        {
            Name = name;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public string Photo { get; set; }
       
        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        public double Price { get; set; }


        public virtual MealGroup MealGroup { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Cuisine Cuisine { get; set; }
    }
}