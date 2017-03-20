using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class ConfirmReserve
    {
        public Restaurant Restaurant { get; set; }
        public List<Table> Tables { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}