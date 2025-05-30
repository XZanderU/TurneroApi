using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurneroApi.Data;
using TurneroApi.Models;

namespace TurneroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurnosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            return await _context.Turnos.OrderBy(t => t.Fecha).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Turno>> PostTurno(Turno turno)
        {
            turno.Fecha = DateTime.UtcNow;
            turno.Estado = "Pendiente";
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTurnos), new { id = turno.Id }, turno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] string nuevoEstado)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            turno.Estado = nuevoEstado;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
