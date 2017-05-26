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
using DAL;
using DAL.Entities;

namespace WebUI.Controllers
{
    public class VisitorsAPIController : ApiController
    {
        private KppContext db = new KppContext();

        // GET: api/VisitorsAPI
        public IQueryable<Visitor> GetVisitors()
        {
            return db.Visitors;
        }

        // GET: api/VisitorsAPI/5
        [ResponseType(typeof(Visitor))]
        public IHttpActionResult GetVisitor(int id)
        {
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return NotFound();
            }

            return Ok(visitor);
        }

        // PUT: api/VisitorsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitor(int id, Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitor.VisitorId)
            {
                return BadRequest();
            }

            db.Entry(visitor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorExists(id))
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

        // POST: api/VisitorsAPI
        [ResponseType(typeof(Visitor))]
        public IHttpActionResult PostVisitor(Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visitors.Add(visitor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visitor.VisitorId }, visitor);
        }

        // DELETE: api/VisitorsAPI/5
        [ResponseType(typeof(Visitor))]
        public IHttpActionResult DeleteVisitor(int id)
        {
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return NotFound();
            }

            db.Visitors.Remove(visitor);
            db.SaveChanges();

            return Ok(visitor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitorExists(int id)
        {
            return db.Visitors.Count(e => e.VisitorId == id) > 0;
        }
    }
}