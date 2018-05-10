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
    [Route("api/Avaliacao")]
    public class AvaliacaoController : Controller
    {
        private readonly mydbContext _context;

        public AvaliacaoController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Avaliacao
        [HttpGet]
        public IEnumerable<Avaliacao> GetAvaliacao()
        {
            return _context.Avaliacao;
        }

        // GET: api/Avaliacao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvaliacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avaliacao = await _context.Avaliacao.SingleOrDefaultAsync(m => m.IdAvaliacao == id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return Ok(avaliacao);
        }

        // PUT: api/Avaliacao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao([FromRoute] int id, [FromBody] Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avaliacao.IdAvaliacao)
            {
                return BadRequest();
            }

            _context.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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

        // POST: api/Avaliacao
        [HttpPost]
        public async Task<IActionResult> PostAvaliacao([FromBody] Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Avaliacao.Add(avaliacao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AvaliacaoExists(avaliacao.IdAvaliacao))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAvaliacao", new { id = avaliacao.IdAvaliacao }, avaliacao);
        }

        // DELETE: api/Avaliacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avaliacao = await _context.Avaliacao.SingleOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            _context.Avaliacao.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return Ok(avaliacao);
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacao.Any(e => e.IdAvaliacao == id);
        }
    }
}