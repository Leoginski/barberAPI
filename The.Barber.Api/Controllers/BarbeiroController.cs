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
    [Route("api/Barbeiro")]
    public class BarbeiroController : Controller
    {
        private readonly mydbContext _context;

        public BarbeiroController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Barbeiro
        [HttpGet]
        public IEnumerable<Barbeiro> GetBarbeiro()
        {
            return _context.Barbeiro;
        }

        // GET: api/Barbeiro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarbeiro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var barbeiro = await _context.Barbeiro.SingleOrDefaultAsync(m => m.IdBarbeiro == id);

            if (barbeiro == null)
            {
                return NotFound();
            }

            return Ok(barbeiro);
        }

        // PUT: api/Barbeiro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarbeiro([FromRoute] int id, [FromBody] Barbeiro barbeiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barbeiro.IdBarbeiro)
            {
                return BadRequest();
            }

            _context.Entry(barbeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarbeiroExists(id))
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

        // POST: api/Barbeiro
        [HttpPost]
        public async Task<IActionResult> PostBarbeiro([FromBody] Barbeiro barbeiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Barbeiro.Add(barbeiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarbeiro", new { id = barbeiro.IdBarbeiro }, barbeiro);
        }

        // DELETE: api/Barbeiro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarbeiro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var barbeiro = await _context.Barbeiro.SingleOrDefaultAsync(m => m.IdBarbeiro == id);
            if (barbeiro == null)
            {
                return NotFound();
            }

            _context.Barbeiro.Remove(barbeiro);
            await _context.SaveChangesAsync();

            return Ok(barbeiro);
        }

        private bool BarbeiroExists(int id)
        {
            return _context.Barbeiro.Any(e => e.IdBarbeiro == id);
        }

        [HttpGet]
        [Route("GetBarbeirosPorBarbearia/{id}")]
        public IEnumerable<Barbeiro> GetBarbeiroPorBarbearia([FromRoute] int id)
        {
            return _context.Barbeiro.Include(x => x.Funcionarios)
                                    .Where(x => x.Funcionarios.Any(y => y.BarbeariaIdBarbearia == id));
        }
    }
}