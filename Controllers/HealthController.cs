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
    public class HealthController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();

        /*// GET: api/Health
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        } */

        // GET: api/Health/5
        /*[ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            if (id == 4)
            {
                Item item = db.Items.Find(id);
                return Ok(item);
            }
            else 
            {
                return NotFound();
            }
        } */

        public List<ItemVM> GetItems()
        {
            return db.Items.Where(i => i.Active == true && i.ItemTypeID == 5).Select(i => new ItemVM
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


        // PUT: api/Health/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ItemID)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Health
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.ItemID }, item);
        }

        // DELETE: api/Health/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
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

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ItemID == id) > 0;
        }
    }
}