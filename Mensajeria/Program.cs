using Mensajeria.dbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuración de conexión con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuración de autorización (aquí no es necesario si no usas roles o políticas)
builder.Services.AddAuthorization();

// Swagger/OpenAPI configuración para documentar tu API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // Activa Swagger para la documentación
    app.UseSwaggerUI();    // UI de Swagger para visualizar y probar la API
}

// No necesitas app.UseAuthentication() si no vas a usar autenticación.

// Habilita el middleware de autorización, si no lo necesitas puedes omitirlo.
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

// Ejecuta la aplicació

app.Run();