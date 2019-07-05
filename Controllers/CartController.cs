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
    public class CartController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();
        public IHttpActionResult PostCart(List<CartVM> model)
        {
            if (model != null)
            {
                var cart = new CartView();
                cart.Cart = new List<CartVM>();
                foreach (var m in model)
                {
                    var item = db.Items.Find(m.Id);
                    cart.Cart.Add(new CartVM
                    {
                        Id = item.ItemID,
                        Name = item.Name,
                        Price = item.Price,
                        Total = m.Count * item.Price,
                        Count = m.Count
                    });
                }
                cart.Total = cart.Cart.Sum(c => c.Total);
                return Ok(cart);
            }
            else
            {
                return Ok();
            }
        }
    }
}