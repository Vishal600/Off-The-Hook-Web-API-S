using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeoutRestaurant.ViewModels
{
    public class CartView
    {
        public List<CartVM> Cart { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}