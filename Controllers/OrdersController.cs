using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TakeoutRestaurant.Models;
using TakeoutRestaurant.ViewModels;

namespace Takeout.Controllers
{
    public class OrdersController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();

        //Get all ordes from the table
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        //Get only one order

        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/Order
        /* [ResponseType(typeof(Order))]
         public IHttpActionResult PostOrder(Order order)
         {
             try
             {
                 //Order table
                 if (order.OrderID == 0)
                     db.Orders.Add(order);
                 else
                     db.Entry(order).State = EntityState.Modified;

                 //OrderItems table
                 foreach (var item in order.OrderItems)
                 {
                     if (item.OrderItemID == 0)
                         db.OrderItems.Add(item);
                     else
                         db.Entry(item).State = EntityState.Modified;
                 }
           */


        //New Order, Checkout
        public IHttpActionResult PostOrder(OrderVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //get item by id
            var item = db.Items.Find(model.ItemID); //Checks if an entity with the primary key value exists

            //save order to Orders table (52-60)
            var order = new Order();
            order.CustomerID = model.CustomerID;

            //save total
            order.GTotal = model.Quantity * item.Price; //Calculating Total
            order.OrderNo = GetOrderNo(); //At line 70
            db.Orders.Add(order); //Add to the order table
            db.SaveChanges(); //Saves changes to the DB



            //save item order to OrderItems table
            db.OrderItems.Add(new OrderItem { ItemID = model.ItemID, Quantity = model.Quantity, OrderID = order.OrderID });
            db.SaveChanges(); //Saving changes

            return Ok(new { order.OrderNo, order.GTotal });
        }

        //Generate a Order No, GUID Generates a Random orderNo
        public string GetOrderNo()
        {
            return Guid.NewGuid().ToString(); //Converting the object to string 
        }


        //Releasing connection, unmanaged resources
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}