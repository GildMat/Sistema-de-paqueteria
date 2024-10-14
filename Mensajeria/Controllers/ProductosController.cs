using Mensajeria.clientes;
using Mensajeria.dbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensajeria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("/productos/")]
    public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    [HttpGet("/productos/{id}")]
    public async Task<ActionResult<Productos>> GetProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    [HttpPost("/productos/post")]
    public async Task<ActionResult<Productos>> PostProducto(Productos producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducto), new { id = producto.CodigoProducto }, producto);
    }

    [HttpPut("/productos/put/{id}")]
    public async Task<IActionResult> PutProducto(int id, Productos producto)
    {
        if (id != producto.CodigoProducto)
        {
            return BadRequest();
        }

        _context.Entry(producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Productos.Any(e => e.CodigoProducto == id))
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

    [HttpDelete("/productos/delete/{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}