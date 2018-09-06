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
using WebAPI.Models;
//To allow request from another application 
//using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    //This has to be applied to all the controllers. Will be difficult if working on a big project so follow the other method: 
    //App_start --> webapi config.cs file 
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class InfoController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Info
        //Retrieve all rows in the InfoTable. 
        public IQueryable<InfoTable> GetInfoTables()
        {
            return db.InfoTables;
        }

        // GET: api/Info/5
        [ResponseType(typeof(InfoTable))]
        public IHttpActionResult GetInfoTable(int id)
        {
            InfoTable infoTable = db.InfoTables.Find(id);
            if (infoTable == null)
            {
                return NotFound();
            }

            return Ok(infoTable);
        }

        // PUT: api/Info/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInfoTable(int id, InfoTable infoTable)
        {
            //This validation will be done in Angular
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            if (id != infoTable.ID)
            {
                return BadRequest();
            }

            db.Entry(infoTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoTableExists(id))
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

        // POST: api/Info - To insert new records. 
        [ResponseType(typeof(InfoTable))]
        public IHttpActionResult PostInfoTable(InfoTable infoTable)
        {
            //This validation will be done in Angular 
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.InfoTables.Add(infoTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = infoTable.ID }, infoTable);
        }

        // DELETE: api/Info/5
        [ResponseType(typeof(InfoTable))]
        public IHttpActionResult DeleteInfoTable(int id)
        {
            InfoTable infoTable = db.InfoTables.Find(id);
            if (infoTable == null)
            {
                return NotFound();
            }

            db.InfoTables.Remove(infoTable);
            db.SaveChanges();

            return Ok(infoTable);
        }

        //To release the resources we have used in this controller. 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoTableExists(int id)
        {
            return db.InfoTables.Count(e => e.ID == id) > 0;
        }
    }
}