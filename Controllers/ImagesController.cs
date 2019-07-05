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
    public class ImagesController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();
        // GET: api/Images/1
        public IHttpActionResult Get(int id)
        {
            return Ok(db.Items.Where(i => i.ItemID == id).Select(i => new
            {
                i.Image
            }).FirstOrDefault());
        }
    }
}