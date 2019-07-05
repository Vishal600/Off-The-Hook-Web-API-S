using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeoutRestaurant.ViewModels
{
    public class ItemVM
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }

        public string Image { get; set; }

        public Nullable<bool> Active { get; set; }
        public Nullable<int> ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }

        public string veg {get; set;}


       
    }
}