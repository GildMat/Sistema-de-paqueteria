using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mensajeria.clientes;

public class NotasCredito
{
    
    [Key]
    [Column("CodigoNotaCredito")]
    public int CodigoNotaCredito { get; set; } // Primary Key
    [Column("TipoNota")]
    public string TipoNota { get; set; } = string.Empty; // 'AnulacionVentas' o 'DevolucionProductos'
    [Column("CodigoVenta")]
    public int CodigoVenta { get; set; } // Foreign Key
    
    public Ventas Ventas { get; set; } = null!; // Navigation Property
    [Column("FechaNota")]
    public DateTime FechaNota { get; set; }
    [Column("MontoNota")]
    public decimal MontoNota { get; set; }
}