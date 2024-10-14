using Mensajeria.clientes;
using Mensajeria.dbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensajeria.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VentaController : Controller
{
    
    private readonly ApplicationDbContext _context;

    public VentaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
    {
        return await _context.Ventas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ventas>> GetVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);

        if (venta == null)
        {
            return NotFound();
        }

        return venta;
    }

    [HttpPost]
    public async Task<ActionResult<Ventas>> PostVenta(Ventas venta)
    {
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVenta), new { id = venta.CodigoVenta }, venta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVenta(int id, Ventas venta)
    {
        if (id != venta.CodigoVenta)
        {
            return BadRequest();
        }

        _context.Entry(venta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Ventas.Any(e => e.CodigoVenta == id))
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
    public async Task<IActionResult> DeleteVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null)
        {
            return NotFound();
        }

        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
}