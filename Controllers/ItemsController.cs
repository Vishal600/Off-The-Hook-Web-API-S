using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TakeoutRestaurant.Models;
using TakeoutRestaurant.ViewModels;

namespace TakeoutRestaurant.Controllers
{
    public class ItemsController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();

        // GET: api/Items
        public List<ItemVM> GetItems()
        {
            return db.Items.Where(i => i.Active == true).Select(i => new ItemVM
            {
                ItemID = i.ItemID,
                Name = i.Name,
                Price = i.Price,
                Image = i.Image,
                veg = i.veg,
                ItemTypeName = i.ItemType.ItemTypeName,
                ItemTypeID = i.ItemTypeID,
             
            }).ToList();
        }

       

        /// <summary>
        /// sort by ItemTypeID
        /// choose between- a) Dessert b) Appetizers and c) Entrees
        /// </summary>
        /// <param name="ItemTypeID"></param>
        /// <returns></returns>
        // GET: api/Items/Sort/1


        [HttpGet]
        public List<ItemVM> Sort(int id)
        {

            if (id == 4)
            {
                return db.Items.Where(i => i.Active == true).Select(i => new ItemVM
                {
                    ItemID = i.ItemID,
                    Name = i.Name,
                    Price = i.Price,
                    veg= i.veg,
                    ItemTypeName = i.ItemType.ItemTypeName,
                    ItemTypeID = i.ItemTypeID,
                    
                }).ToList();

            } 
            else { 
                return db.Items.Where(i => i.ItemTypeID == id && i.Active == true).Select(i => new ItemVM
                {
                    ItemID = i.ItemID,
                    Name = i.Name,
                    Price = i.Price,
                    veg = i.veg,
                    ItemTypeName = i.ItemType.ItemTypeName,
                    ItemTypeID = i.ItemTypeID,
                    
                }).ToList();
            }
        }


        // POST: api/Items
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.ItemTypeID }, item);
        }


        /*  Returns just the URI of the new resource. 
        This will include the Id, which the client won't know yet 
        (at least in a typical scenario where the db generates the id),
        and that is the main purpose of the method. 
        It's standard with REST to return that when POSTing a new resource,
        but it's not compulsory or anything. If you don't need it, you could just return a 201
        */

        // DELETE: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id) //Take the item ID as a parameter
        {
            Item item = db.Items.Find(id); //Looks for the ID
            if (item == null)
            {
                return NotFound(); //If its null returns not found
            }

            db.Items.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }


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
