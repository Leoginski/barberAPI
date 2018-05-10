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
    [Route("api/Cidade")]
    public class CidadeController : Controller
    {
        private readonly mydbContext _context;

        public CidadeController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Cidade
        [HttpGet]
        public IEnumerable<Cidade> GetCidade()
        {
            return _context.Cidade;
        }

        // GET: api/Cidade/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCidade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cidade = await _context.Cidade.SingleOrDefaultAsync(m => m.IdCidade == id);

            if (cidade == null)
            {
                return NotFound();
            }

            return Ok(cidade);
        }

        // PUT: api/Cidade/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade([FromRoute] int id, [FromBody] Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cidade.IdCidade)
            {
                return BadRequest();
            }

            _context.Entry(cidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
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

        // POST: api/Cidade
        [HttpPost]
        public async Task<IActionResult> PostCidade([FromBody] Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cidade.Add(cidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = cidade.IdCidade }, cidade);
        }

        // DELETE: api/Cidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cidade = await _context.Cidade.SingleOrDefaultAsync(m => m.IdCidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidade.Remove(cidade);
            await _context.SaveChangesAsync();

            return Ok(cidade);
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidade.Any(e => e.IdCidade == id);
        }
    }
}