using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mensajeria.clientes;

public class Ventas
{
    [Key]
    [Column("CodigoVenta")]
    public int CodigoVenta { get; set; } // Primary Key
    [Column("TipoVenta")]
    public string TipoVenta { get; set; } = string.Empty; // 'VentaXMenor' o 'VentaXMayor'
    [Column("FechaVenta")]
    public DateTime FechaVenta { get; set; }
    [Column("TotalVenta")]
    public decimal TotalVenta { get; set; }
}