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
    [Route("api/Funcionarios")]
    public class FuncionariosController : Controller
    {
        private readonly mydbContext _context;

        public FuncionariosController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public IEnumerable<Funcionarios> GetFuncionarios()
        {
            return _context.Funcionarios;
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionarios = await _context.Funcionarios.SingleOrDefaultAsync(m => m.BarbeariaIdBarbearia == id);

            if (funcionarios == null)
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }

        // PUT: api/Funcionarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionarios([FromRoute] int id, [FromBody] Funcionarios funcionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionarios.BarbeariaIdBarbearia)
            {
                return BadRequest();
            }

            _context.Entry(funcionarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionariosExists(id))
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

        // POST: api/Funcionarios
        [HttpPost]
        public async Task<IActionResult> PostFuncionarios([FromBody] Funcionarios funcionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Funcionarios.Add(funcionarios);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuncionariosExists(funcionarios.BarbeariaIdBarbearia))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuncionarios", new { id = funcionarios.BarbeariaIdBarbearia }, funcionarios);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionarios = await _context.Funcionarios.SingleOrDefaultAsync(m => m.BarbeariaIdBarbearia == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();

            return Ok(funcionarios);
        }

        private bool FuncionariosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.BarbeariaIdBarbearia == id);
        }
    }
}