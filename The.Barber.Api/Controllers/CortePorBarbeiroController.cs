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
    [Route("api/CortePorBarbeiro")]
    public class CortePorBarbeiroController : Controller
    {
        private readonly mydbContext _context;

        public CortePorBarbeiroController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/CortePorBarbeiro
        [HttpGet]
        public IEnumerable<CortePorBarbeiro> GetCortePorBarbeiro()
        {
            return _context.CortePorBarbeiro;
        }

        // GET: api/CortePorBarbeiro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCortePorBarbeiro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cortePorBarbeiro = await _context.CortePorBarbeiro.SingleOrDefaultAsync(m => m.CorteIdCorte == id);

            if (cortePorBarbeiro == null)
            {
                return NotFound();
            }

            return Ok(cortePorBarbeiro);
        }

        // PUT: api/CortePorBarbeiro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCortePorBarbeiro([FromRoute] int id, [FromBody] CortePorBarbeiro cortePorBarbeiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cortePorBarbeiro.CorteIdCorte)
            {
                return BadRequest();
            }

            _context.Entry(cortePorBarbeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CortePorBarbeiroExists(id))
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

        // POST: api/CortePorBarbeiro
        [HttpPost]
        public async Task<IActionResult> PostCortePorBarbeiro([FromBody] CortePorBarbeiro cortePorBarbeiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CortePorBarbeiro.Add(cortePorBarbeiro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CortePorBarbeiroExists(cortePorBarbeiro.CorteIdCorte))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCortePorBarbeiro", new { id = cortePorBarbeiro.CorteIdCorte }, cortePorBarbeiro);
        }

        // DELETE: api/CortePorBarbeiro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCortePorBarbeiro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cortePorBarbeiro = await _context.CortePorBarbeiro.SingleOrDefaultAsync(m => m.CorteIdCorte == id);
            if (cortePorBarbeiro == null)
            {
                return NotFound();
            }

            _context.CortePorBarbeiro.Remove(cortePorBarbeiro);
            await _context.SaveChangesAsync();

            return Ok(cortePorBarbeiro);
        }

        private bool CortePorBarbeiroExists(int id)
        {
            return _context.CortePorBarbeiro.Any(e => e.CorteIdCorte == id);
        }
    }
}