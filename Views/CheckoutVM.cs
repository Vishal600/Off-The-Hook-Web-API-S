using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeoutRestaurant.ViewModels
{
    public class CheckoutVM
    {
        public List<CheckoutView> Checkout { get; set; }

        public int CustomerID { get; set; }
    }
}