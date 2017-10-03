using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class TableViewModel
    {
        public int Id { get; set; }

        public int Seats { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool Reserved { get; set; }
        public bool ReservedAndConfirmed { get; set; }

    }
}