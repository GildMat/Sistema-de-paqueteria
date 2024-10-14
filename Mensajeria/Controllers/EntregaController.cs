using Mensajeria.clientes;
using Mensajeria.dbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensajeria.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EntregaController : Controller
{
    private readonly ApplicationDbContext _context;

    public EntregaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Entregas>>> GetEntregas()
    {
        return await _context.Entregas.Include(e => e.Cliente).Include(e => e.Producto).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Entregas>> GetEntrega(int id)
    {
        var entrega = await _context.Entregas.Include(e => e.Cliente).Include(e => e.Producto).FirstOrDefaultAsync(e => e.CodigoEntrega == id);

        if (entrega == null)
        {
            return NotFound();
        }

        return entrega;
    }

    [HttpPost]
    public async Task<ActionResult<Entregas>> PostEntrega(Entregas entrega)
    {
        _context.Entregas.Add(entrega);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEntrega), new { id = entrega.CodigoEntrega }, entrega);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEntrega(int id, Entregas entrega)
    {
        if (id != entrega.CodigoEntrega)
        {
            return BadRequest();
        }

        _context.Entry(entrega).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Entregas.Any(e => e.CodigoEntrega == id))
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
    public async Task<IActionResult> DeleteEntrega(int id)
    {
        var entrega = await _context.Entregas.FindAsync(id);
        if (entrega == null)
        {
            return NotFound();
        }

        _context.Entregas.Remove(entrega);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}