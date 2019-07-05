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

namespace TakeoutRestaurant.Controllers.Login
{ 
    public class RegisterController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();
        // POST api/Register

            
        public IHttpActionResult Post(User user) //Parameter "user" from class "User"
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Username == user.Username))
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Ok("The account was created successfully");
                }
            }
            return BadRequest("The Username & Password already exists");
        }
    }

    
}



/*namespace Takeout.Controllers.Login
{
    public class RegisterController : ApiController
    {
        private TakeoutDBEntities db = new TakeoutDBEntities();
        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != user.ID)
            {
                return BadRequest();
            }
            db.Entry(user).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }
        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(string id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool UserExists(string id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
} */
