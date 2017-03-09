﻿using System.ComponentModel.DataAnnotations;

namespace CityGoodTaste
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "PhoneName", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "User", ResourceType = typeof(Resources.Resource))]
        public virtual User User { get; set; }
    }
}