using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models
{

    public class SearchCategory<T>
    {
        public T Category { set; get; }
        public bool IsSelected { set; get; }
        public int Count { set; get; }
    }
}