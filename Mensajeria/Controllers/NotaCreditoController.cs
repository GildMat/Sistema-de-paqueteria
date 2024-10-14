using Mensajeria.clientes;
using Mensajeria.dbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensajeria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotaCreditoController : Controller
{
    private readonly ApplicationDbContext _context;

    public NotaCreditoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotasCredito>>> GetNotasCredito()
    {
        return await _context.NotasCredito.Include(nc => nc.Ventas).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NotasCredito>> GetNotaCredito(int id)
    {
        var notaCredito = await _context.NotasCredito.Include(nc => nc.Ventas).FirstOrDefaultAsync(nc => nc.CodigoNotaCredito == id);

        if (notaCredito == null)
        {
            return NotFound();
        }

        return notaCredito;
    }

    [HttpPost]
    public async Task<ActionResult<NotasCredito>> PostNotaCredito(NotasCredito notaCredito)
    {
        _context.NotasCredito.Add(notaCredito);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNotaCredito), new { id = notaCredito.CodigoNotaCredito }, notaCredito);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutNotaCredito(int id, NotasCredito notaCredito)
    {
        if (id != notaCredito.CodigoNotaCredito)
        {
            return BadRequest();
        }

        _context.Entry(notaCredito).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.NotasCredito.Any(e => e.CodigoNotaCredito == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotaCredito(int id)
    {
        var notaCredito = await _context.NotasCredito.FindAsync(id);
        if (notaCredito == null)
        {
            return NotFound();
        }

        _context.NotasCredito.Remove(notaCredito);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
}