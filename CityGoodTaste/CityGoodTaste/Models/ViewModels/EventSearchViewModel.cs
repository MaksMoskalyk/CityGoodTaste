using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{
    public class EventSearchViewModel
    {
        public bool IsSelectedAnyCategory { set; get; }
        public List<RestaurantEvent> Events { set; get; }
        public List<SearchCategory<EventType>> Types { set; get; }
    }

}
