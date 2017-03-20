using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class OrderFood
    {
        public List<Meal> meal { get; set; }
        public List<int> count { get; set; }

        public Currency currency { get; set; }
    }
}