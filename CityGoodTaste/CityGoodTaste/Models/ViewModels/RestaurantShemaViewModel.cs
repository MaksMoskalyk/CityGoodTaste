using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models.ViewModels
{
    public class RestaurantShemaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<TableViewModel> Tables { get; set; }
        public int XLength { get; set; }
        public int YLength { get; set; }        
    }
}