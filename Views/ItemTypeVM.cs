using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeoutRestaurant.ViewModels
{
    public class ItemTypeVM
    {
        /*public int ItemID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }*/
        public Nullable<int> ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }
    }
}