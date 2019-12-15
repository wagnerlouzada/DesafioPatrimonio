using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Patrimonio;

namespace Patrimonio.Controllers
{
    public class PatrimoniosController : ApiController
    {
        private PatrimonioEntities db = new PatrimonioEntities();

        /// <summary>
        /// Obtem todos os Patrimonios.
        /// GET api/Patrimonios
        /// </summary>
        public IQueryable<Patrimonio> GetPatrimonio()
        {
            return db.Patrimonio;
        }

        /// <summary>
        /// Obtem dados de um Patrimonio.
        /// GET api/Patrimonio/5
        /// </summary>
        [ResponseType(typeof(Patrimonio))]
        public async Task<IHttpActionResult> GetPatrimonio(long id)
        {
            Patrimonio patrimonio = await db.Patrimonio.FindAsync(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        /// <summary>
        /// Atualiza dados de um Patrimonio.
        /// PUT api/Patrimonios/5
        /// </summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatrimonio(long id, Patrimonio patrimonio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patrimonio.Tombo)
            {
                return BadRequest();
            }

            db.Entry(patrimonio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatrimonioExists(id))
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

        /// <summary>
        /// Cria uma novo Patrimonio.
        /// POST api/Patrimonios
        /// </summary>
        [ResponseType(typeof(Patrimonio))]
        public async Task<IHttpActionResult> PostPatrimonio(Patrimonio patrimonio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patrimonio.Add(patrimonio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patrimonio.Tombo }, patrimonio);
        }

        /// <summary>
        /// Elimina um Patrimonio.
        /// DELETE api/Patrimonios/5
        /// </summary>
        [ResponseType(typeof(Patrimonio))]
        public async Task<IHttpActionResult> DeletePatrimonio(long id)
        {
            Patrimonio patrimonio = await db.Patrimonio.FindAsync(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            db.Patrimonio.Remove(patrimonio);
            await db.SaveChangesAsync();

            return Ok(patrimonio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatrimonioExists(long id)
        {
            return db.Patrimonio.Count(e => e.Tombo == id) > 0;
        }
    }
}