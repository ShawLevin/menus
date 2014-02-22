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
using Menulator.Models;
using Menulator.DataAccess;

namespace Menulator.Controllers
{
    public class OrderItemController : ApiController
    {
        private MenulatorContext db = new MenulatorContext();

        // GET api/OrderItem
        public IQueryable<OrderItem> GetOrderItems()
        {
            return db.OrderItems;
        }

        // GET api/OrderItem/5
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult GetOrderItem(int id)
        {
            OrderItem orderitem = db.OrderItems.Find(id);
            if (orderitem == null)
            {
                return NotFound();
            }

            return Ok(orderitem);
        }

        // PUT api/OrderItem/5
        public IHttpActionResult PutOrderItem(int id, OrderItem orderitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderitem.OrderItemID)
            {
                return BadRequest();
            }

            db.Entry(orderitem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
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

        // POST api/OrderItem
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult PostOrderItem(OrderItem orderitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderItems.Add(orderitem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderitem.OrderItemID }, orderitem);
        }

        // DELETE api/OrderItem/5
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult DeleteOrderItem(int id)
        {
            OrderItem orderitem = db.OrderItems.Find(id);
            if (orderitem == null)
            {
                return NotFound();
            }

            db.OrderItems.Remove(orderitem);
            db.SaveChanges();

            return Ok(orderitem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderItemExists(int id)
        {
            return db.OrderItems.Count(e => e.OrderItemID == id) > 0;
        }
    }
}