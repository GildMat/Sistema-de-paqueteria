using Mensajeria.clientes;
using Microsoft.EntityFrameworkCore;

namespace Mensajeria.dbContext;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ClientesModels> Clientes { get; set; } = null!;
    public DbSet<Productos> Productos { get; set; } = null!;
    public DbSet<Ventas> Ventas { get; set; } = null!;
    public DbSet<NotasCredito> NotasCredito { get; set; } = null!;
    public DbSet<Entregas> Entregas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación entre NotaCredito y Venta
        modelBuilder.Entity<NotasCredito>()
            .HasOne(nc => nc.Ventas)
            .WithMany()
            .HasForeignKey(nc => nc.CodigoVenta);

        // Relación entre Entrega y Cliente
        modelBuilder.Entity<Entregas>()
            .HasOne(e => e.Cliente)
            .WithMany()
            .HasForeignKey(e => e.CodigoCliente);

        // Relación entre Entrega y Producto
        modelBuilder.Entity<Entregas>()
            .HasOne(e => e.Producto)
            .WithMany()
            .HasForeignKey(e => e.CodigoProducto);
    }
    
}