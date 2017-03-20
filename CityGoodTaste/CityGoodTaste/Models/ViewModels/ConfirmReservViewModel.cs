using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models.ViewModels
{
    public class ConfirmReservViewModel
    {
        public int RestaurantId { get; set; }
        public int SchemaId { get; set; }
        public List<TableReservation> Reservation { get; set; }
    }
}