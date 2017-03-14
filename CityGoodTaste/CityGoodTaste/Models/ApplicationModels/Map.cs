﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class Map
    {
        public Map()
        {
        }
        public Map(double latitude, double longitude, int zoom)
        {
            Latitude = latitude;
            Longitude = longitude;
            Zoom = zoom;
        }

        [Key]
        public int id { get; set; }

        [Display(Name = "Latitude", ResourceType = typeof(Resources.Resource))]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", ResourceType = typeof(Resources.Resource))]
        public double Longitude { get; set; }

        [Display(Name = "Zoom", ResourceType = typeof(Resources.Resource))]
        public int Zoom { get; set; }
    }
}