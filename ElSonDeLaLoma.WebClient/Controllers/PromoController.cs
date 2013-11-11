using ElSonDeLaLoma.Business;
using ElSonDeLaLoma.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ElSonDeLaLoma.Controllers
{
    public class PromoController : ApiController
    {
        PromoesMngr mngr = new PromoesMngr();

        // GET api/Promo
        public IQueryable<Promo> GetPromoes()
        {
            return mngr.GetPromoes();
        }

        // GET api/Promo/5
        [ResponseType(typeof(Promo))]
        public IHttpActionResult GetPromo(Guid id)
        {
            var promo = mngr.Find(id);
            if (promo == null)
            {
                return NotFound();
            }

            return Ok(promo);
        }

        // PUT api/Promo/5
        public IHttpActionResult PutPromo(Guid id, Promo promo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promo.ID)
            {
                return BadRequest();
            }

            try
            {
                mngr.Save(promo);
            }
            catch (Exception)
            {
                if (!PromoExists(id))
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

        // POST api/Promo
        [ResponseType(typeof(Promo))]
        public IHttpActionResult PostPromo(Promo promo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                mngr.New(promo);
            }
            catch (Exception)
            {
                if (PromoExists(promo.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = promo.ID }, promo);
        }

        // DELETE api/Promo/5
        [ResponseType(typeof(Promo))]
        public IHttpActionResult DeletePromo(Guid id)
        {
            Promo promo = mngr.Find(id);
            if (PromoExists(id) == false)
            {
                return NotFound();
            }

            mngr.Delete(promo);

            return Ok(promo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mngr.Dispose();
            }
            base.Dispose(disposing);
        }

        bool PromoExists(Guid id)
        {
            return mngr.Find(id) != null;
        }
    }
}