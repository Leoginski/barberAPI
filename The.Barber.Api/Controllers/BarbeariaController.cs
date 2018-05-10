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
    [Route("api/Barbearia")]
    public class BarbeariaController : Controller
    {
        private readonly mydbContext _context;

        public BarbeariaController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Barbearia
        [HttpGet]
        public IEnumerable<Barbearia> GetBarbearia()
        {
            return _context.Barbearia;
        }

        // GET: api/Barbearia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarbearia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var barbearia = await _context.Barbearia.SingleOrDefaultAsync(m => m.IdBarbearia == id);

            if (barbearia == null)
            {
                return NotFound();
            }

            return Ok(barbearia);
        }

        // PUT: api/Barbearia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarbearia([FromRoute] int id, [FromBody] Barbearia barbearia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barbearia.IdBarbearia)
            {
                return BadRequest();
            }

            _context.Entry(barbearia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarbeariaExists(id))
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

        // POST: api/Barbearia
        [HttpPost]
        public async Task<IActionResult> PostBarbearia([FromBody] Barbearia barbearia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Barbearia.Add(barbearia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarbearia", new { id = barbearia.IdBarbearia }, barbearia);
        }

        // DELETE: api/Barbearia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarbearia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var barbearia = await _context.Barbearia.SingleOrDefaultAsync(m => m.IdBarbearia == id);
            if (barbearia == null)
            {
                return NotFound();
            }

            _context.Barbearia.Remove(barbearia);
            await _context.SaveChangesAsync();

            return Ok(barbearia);
        }

        private bool BarbeariaExists(int id)
        {
            return _context.Barbearia.Any(e => e.IdBarbearia == id);
        }
    }
}