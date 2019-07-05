using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TakeoutRestaurant.Models;
using TakeoutRestaurant.ViewModels;

namespace TakeoutRestaurant.Controllers
{
    public class CheckoutController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();
        //New Order, Checkout
        public IHttpActionResult PostCheckout(CheckoutVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = new Order();
            order.GTotal = 0;
            foreach (var checkout in model.Checkout)
            {
                //get item by id
                var item = db.Items.Find(checkout.Id); //Checks if an entity with the primary key value exists
                //save total
                order.GTotal += checkout.Count * item.Price; //Calculating Total
            }

            if (model.CustomerID != 0)
            {
                order.CustomerID = model.CustomerID;
            }
            order.OrderNo = GetOrderNo(); 
            db.Orders.Add(order); //Add to the order table
            db.SaveChanges(); //Saves changes to the DB


            //save item order to OrderItems table
            foreach (var item in model.Checkout)
            {
                db.OrderItems.Add(new OrderItem { ItemID = item.Id, Quantity = item.Count, OrderID = order.OrderID });
                db.SaveChanges(); //Saving changes
            }

            return Ok(new { order.OrderNo, order.GTotal });
        } 

        

    //Generate a Order No, GUID Generates a Random orderNo
    public string GetOrderNo()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks); 

  
           // return Guid.NewGuid().ToString(); //Converting the object to string 


        }


    }
}
