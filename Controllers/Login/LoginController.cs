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


namespace Takeout.Controllers
{
    public class LoginController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();

        // POST api/Login
        public IHttpActionResult Post([FromBody]User user) //Action Param only comes from the body of the HttpMessage that is incoming
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (db.Users.Any(u => u.Username == user.Username && u.Password == user.Password)) //"Any" determines if any of the elements satifies a condition
                    //the left side of the lambda operator specifies the input and the right side specifies the code that works with it.
                {
                    return Ok("Login Success");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "invalid credentials");
                }
            }

        }
    }
}
