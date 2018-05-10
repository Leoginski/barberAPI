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
    [Route("api/Corte")]
    public class CorteController : Controller
    {
        private readonly mydbContext _context;

        public CorteController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Corte
        [HttpGet]
        public IEnumerable<Corte> GetCorte()
        {
            return _context.Corte;
        }

        // GET: api/Corte/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCorte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var corte = await _context.Corte.SingleOrDefaultAsync(m => m.IdCorte == id);

            if (corte == null)
            {
                return NotFound();
            }

            return Ok(corte);
        }

        // PUT: api/Corte/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorte([FromRoute] int id, [FromBody] Corte corte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != corte.IdCorte)
            {
                return BadRequest();
            }

            _context.Entry(corte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorteExists(id))
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

        // POST: api/Corte
        [HttpPost]
        public async Task<IActionResult> PostCorte([FromBody] Corte corte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Corte.Add(corte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorte", new { id = corte.IdCorte }, corte);
        }

        // DELETE: api/Corte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var corte = await _context.Corte.SingleOrDefaultAsync(m => m.IdCorte == id);
            if (corte == null)
            {
                return NotFound();
            }

            _context.Corte.Remove(corte);
            await _context.SaveChangesAsync();

            return Ok(corte);
        }

        private bool CorteExists(int id)
        {
            return _context.Corte.Any(e => e.IdCorte == id);
        }
    }
}