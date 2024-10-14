using Mensajeria.clientes;
using Mensajeria.dbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensajeria.Controllers;


[ApiController]
[Route("api/[controller]")]
public class FiltrosCotroller : Controller
{
    private readonly ApplicationDbContext _context;

    public FiltrosCotroller(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("/busquedaNombre/{nombre}")]
    public async Task<ActionResult<IEnumerable<ClientesModels>>> SearchClientesByName(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            return BadRequest("El nombre no puede estar vacío.");
        }

        var clientes = await _context.Clientes
            .Where(c => c.NombresCliente.ToLower().Contains(nombre.ToLower()))
            .ToListAsync();


        if (clientes == null || clientes.Count == 0)
        {
            return NotFound($"No se encontraron clientes con el nombre '{nombre}'.");
        }

        return Ok(clientes);
    }
    
    
    [HttpGet("/busquedaApellido/{apellido}")]
    public async Task<ActionResult<IEnumerable<ClientesModels>>> SearchClientesByApellido(string apellido)
    {
        if (string.IsNullOrWhiteSpace(apellido))
        {
            return BadRequest("El nombre no puede estar vacío.");
        }

        var clientes = await _context.Clientes
            .Where(c => c.ApellidosCliente.ToLower().Contains(apellido.ToLower()))
            .ToListAsync();


        if (clientes == null || clientes.Count == 0)
        {
            return NotFound($"No se encontraron clientes con el apellido '{apellido}'.");
        }

        return Ok(clientes);
    }
    
    [HttpGet("/busquedaNit/{nit}")]
    public async Task<ActionResult<IEnumerable<ClientesModels>>> SearchClientesByNit(string nit)
    {
        if (string.IsNullOrWhiteSpace(nit))
        {
            return BadRequest("El NIT no puede estar vacío.");
        }

        var clientes = await _context.Clientes
            .Where(c => c.NIT.ToLower().Contains(nit.ToLower()))
            .ToListAsync();

        if (clientes.Count == 0)
        {
            return NotFound($"No se encontraron clientes con el NIT '{nit}'.");
        }

        return Ok(clientes);
    }
    
    [HttpGet("/busquedaCodigoProducto/{codigoProducto}")]
    public async Task<ActionResult<Productos>> SearchProductoByCodigo(int codigoProducto)
    {
        // Verificamos que el código del producto no sea cero o negativo
        if (codigoProducto <= 0)
        {
            return BadRequest("El código del producto no puede ser cero o negativo.");
        }

        // Buscamos el producto por su código
        var producto = await _context.Productos
            .FirstOrDefaultAsync(p => p.CodigoProducto == codigoProducto);

        // Verificamos si se encontró el producto
        if (producto == null)
        {
            return NotFound($"No se encontró un producto con el código '{codigoProducto}'.");
        }

        // Retornamos el producto encontrado
        return Ok(producto);
    }
    
    [HttpGet("/productosVencidosPorFecha/{fechaSeleccionada}")]
    public async Task<ActionResult<IEnumerable<Productos>>> GetProductosVencidosPorFecha(DateTime fechaSeleccionada)
    {
        // Validamos que la fecha seleccionada no sea una fecha futura
        if (fechaSeleccionada > DateTime.Now)
        {
            return BadRequest("La fecha seleccionada no puede ser una fecha futura.");
        }

        // Buscamos los productos cuya fecha de vencimiento sea menor o igual a la fecha seleccionada
        var productosVencidos = await _context.Productos
            .Where(p => p.FechaVencimiento <= fechaSeleccionada)
            .ToListAsync();

        // Verificamos si se encontraron productos vencidos
        if (productosVencidos == null || productosVencidos.Count == 0)
        {
            return NotFound($"No se encontraron productos vencidos hasta la fecha '{fechaSeleccionada.ToShortDateString()}'.");
        }

        // Retornamos los productos vencidos
        return Ok(productosVencidos);
    }




}