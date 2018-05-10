using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The.Barber.Api.Data;
using The.Barber.Api.Models;

namespace The.Barber.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Estado")]
    public class EstadoController : Controller
    {
        private readonly mydbContext _context;

        public EstadoController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Estado
        [HttpGet]
        public IEnumerable<Estado> GetEstado()
        {
            return _context.Estado;
        }

        // GET: api/Estado/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstado([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estado = await _context.Estado.SingleOrDefaultAsync(m => m.IdEstado == id);

            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/Estado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado([FromRoute] int id, [FromBody] Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estado
        [HttpPost]
        public async Task<IActionResult> PostEstado([FromBody] Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Estado.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = estado.IdEstado }, estado);
        }

        // DELETE: api/Estado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estado = await _context.Estado.SingleOrDefaultAsync(m => m.IdEstado == id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estado.Remove(estado);
            await _context.SaveChangesAsync();

            return Ok(estado);
        }

        private bool EstadoExists(int id)
        {
            return _context.Estado.Any(e => e.IdEstado == id);
        }
    }
}