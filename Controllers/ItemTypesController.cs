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
    public class ItemTypesController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();

        // GET: api/ItemTypes
        public List<ItemTypeVM> GetItemTypes()
        {
            return db.ItemTypes.Select(i => new ItemTypeVM
            {
                ItemTypeID = i.ItemTypeID,
                ItemTypeName = i.ItemTypeName
            }).ToList();
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