using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The.Barber.Api.Data;
using The.Barber.Api.Models;
using The.Barber.Api.ViewModels;

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

            if (agendamento.IdUsuario != null && agendamento.IdUsuario != "")
            {
                var result = _context.Cliente.SingleOrDefault(x => x.UsuarioId.ToUpper() == agendamento.IdUsuario.ToUpper());
                agendamento.ClienteIdCliente = result.IdCliente;
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


        // GET: api/Agendamento
        [HttpGet]
        [Route("getAgendamentoPorIdClienteBarbeiro/{id}")]
        public IEnumerable<AgendamentoViewModel> GetAgendamentoById([FromRoute] int id)
        {
            var result = Mapper.Map<List<AgendamentoViewModel>>(_context.Agendamento.Include(x => x.BarbeiroIdBarbeiroNavigation)
                                       .Include(x => x.ClienteIdClienteNavigation)
                                       .Include(x => x.Avaliacao)
                                       .Where(x => x.BarbeiroIdBarbeiro == id || x.ClienteIdCliente == id)
                                       .ToList());

            return result;
        }

        [HttpGet]
        [Route("getAgendamentoPorIdUsuario/{id}")]
        public IEnumerable<AgendamentoViewModel> GetAgendamentoById([FromRoute] string id)
        {
            var result = Mapper.Map<List<AgendamentoViewModel>>(_context.Agendamento.Include(x => x.BarbeiroIdBarbeiroNavigation)
                                       .Include(x => x.ClienteIdClienteNavigation)
                                       .Include(x => x.Avaliacao)
                                       .Where(x => x.ClienteIdClienteNavigation.UsuarioId == id || x.BarbeiroIdBarbeiroNavigation.UsuarioId == id)
                                       .ToList());

            return result;
        }
    }
}