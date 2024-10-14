using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mensajeria.clientes;

public class ClientesModels
{
    [Key]
    [Column("CodigoCliente")]
    public int CodigoCliente { get; set; } // Primary Key
    [Column("NombresCliente")]
    public string NombresCliente { get; set; } = string.Empty;
    [Column("ApellidosCliente")]
    public string ApellidosCliente { get; set; } = string.Empty;
    [Column("NIT")]
    public string? NIT { get; set; }
    [Column("DireccionCliente")]
    public string? DireccionCliente { get; set; }
    [Column("CategoriaCliente")]
    public string? CategoriaCliente { get; set; }
    [Column("EstadoCliente")]
    public string? EstadoCliente { get; set; }
}