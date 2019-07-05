using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TakeoutRestaurant.Models;
using TakeoutRestaurant.ViewModels;



namespace TakeoutRestaurant.Controllers
{

    public class AccountController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();

        // GET: api/Account
        public List<ItemVM> GetItems()
        {
            return db.Items.Select(i => new ItemVM
            {
                ItemID = i.ItemID,
                Name = i.Name,
                Price = i.Price,
                ItemTypeName = i.ItemType.ItemTypeName,
                ItemTypeID = i.ItemTypeID,
                Active = i.Active
            }).ToList();
        }


        [HttpGet]
        public IHttpActionResult ReAdd(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Active = true;
            db.SaveChanges();

            return Ok("Successful Add");
        }

        //Soft Delete: api/Admin/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Active = false;
            db.SaveChanges();

            return Ok("Soft Deleted");
        }


    }
}