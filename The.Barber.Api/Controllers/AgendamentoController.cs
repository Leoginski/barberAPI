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
    [Route("api/Agendamento")]
    public class AgendamentoController : Controller
    {
        private readonly mydbContext _context;

        public AgendamentoController(mydbContext context)
        {
            _context = context;
        }

        // GET: api/Agendamento
        [HttpGet]
        public IEnumerable<Agendamento> GetAgendamento()
        {
            return _context.Agendamento;
        }

        // GET: api/Agendamento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgendamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamento = await _context.Agendamento.SingleOrDefaultAsync(m => m.ClienteIdCliente == id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return Ok(agendamento);
        }

        // PUT: api/Agendamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento([FromRoute] int id, [FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agendamento.ClienteIdCliente)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
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

        // POST: api/Agendamento
        [HttpPost]
        public async Task<IActionResult> PostAgendamento([FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Agendamento.Add(agendamento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AgendamentoExists(agendamento.ClienteIdCliente))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAgendamento", new { id = agendamento.ClienteIdCliente }, agendamento);
        }

        // DELETE: api/Agendamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamento = await _context.Agendamento.SingleOrDefaultAsync(m => m.ClienteIdCliente == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();

            return Ok(agendamento);
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamento.Any(e => e.ClienteIdCliente == id);
        }
    }
}