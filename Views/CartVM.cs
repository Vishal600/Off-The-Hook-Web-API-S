using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeoutRestaurant.ViewModels
{
    public class CartVM
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Name { get; set; }
    }
}