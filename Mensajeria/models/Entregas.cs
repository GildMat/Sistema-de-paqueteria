using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mensajeria.clientes;

public class Entregas
{
    
    [Key]
    [Column("CodigoEntrega")]
    public int CodigoEntrega { get; set; } // Primary Key
    [Column("CodigoCliente")]
    public int CodigoCliente { get; set; } // Foreign Key
    [Column("ClientesModels")]
    public ClientesModels Cliente { get; set; } = null!; // Navigation Property
    [Column("CodigoProducto")]
    public int CodigoProducto { get; set; } // Foreign Key
    
    public Productos Producto { get; set; } = null!; // Navigation Property
    [Column("FechaEntrega")]
    public DateTime FechaEntrega { get; set; }
    [Column("EstadoEntrega")]
    public string EstadoEntrega { get; set; } = string.Empty;
    [Column("UbicacionEntrega")]
    public string? UbicacionEntrega { get; set; }
}