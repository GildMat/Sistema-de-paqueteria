using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mensajeria.clientes;

public class Productos
{
    [Key]
    [Column("CodigoProducto")]
    public int CodigoProducto { get; set; } // Primary Key
    [Column("Descripcion")]
    public string Descripcion { get; set; } = string.Empty;
    [Column("CodigoProveedor")]
    public int? CodigoProveedor { get; set; } // Nullable
    [Column("FechaVencimiento")]
    public DateTime? FechaVencimiento { get; set; } // Nullable
    [Column("UbicacionFisica")]
    public string? UbicacionFisica { get; set; }
    [Column("ExistenciaMinima")]
    public int ExistenciaMinima { get; set; }
}