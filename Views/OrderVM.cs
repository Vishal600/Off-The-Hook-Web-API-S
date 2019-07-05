using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeoutRestaurant.ViewModels
{
    public class OrderVM
    {
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public int CustomerID { get; set; }
    }
}