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
    public class MarcasController : ApiController
    {
        private PatrimonioEntities db = new PatrimonioEntities();

        /// <summary>
        /// Obtem Todas as Marcas.
        /// GET api/Marcas
        /// </summary>
        public IQueryable<Marcas> GetMarcas()
        {
            return db.Marcas;
        }

        /// <summary>
        /// Obtem dados de uma marca.
        /// GET api/Marcas/5
        /// </summary>
        [ResponseType(typeof(Marcas))]
        public async Task<IHttpActionResult> GetMarcas(long id)
        {
            Marcas marcas = await db.Marcas.FindAsync(id);
            if (marcas == null)
            {
                return NotFound();
            }

            return Ok(marcas);
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Atualiza dados de um Patrimonio.
        /// PUT api/Marcas
        /// </summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarcas(long id, Marcas marcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marcas.MarcaId)
            {
                return BadRequest();
            }

            db.Entry(marcas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcasExists(id))
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

        // POST api/<controller>
        /// <summary>
        /// Cria uma nova marca.
        /// POST api/Marcas
        /// </summary>
        [ResponseType(typeof(Marcas))]
        public async Task<IHttpActionResult> PostMarcas(Marcas marcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marcas.Add(marcas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = marcas.MarcaId }, marcas);
        }

        /// <summary>
        /// Elimina uma marca.
        /// DELETE api/Marcas/5
        /// </summary>
        [ResponseType(typeof(Marcas))]
        public async Task<IHttpActionResult> DeleteMarcas(long id)
        {
            Marcas marcas = await db.Marcas.FindAsync(id);
            if (marcas == null)
            {
                return NotFound();
            }

            db.Marcas.Remove(marcas);
            await db.SaveChangesAsync();

            return Ok(marcas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcasExists(long id)
        {
            return db.Marcas.Count(e => e.MarcaId == id) > 0;
        }
    }
}