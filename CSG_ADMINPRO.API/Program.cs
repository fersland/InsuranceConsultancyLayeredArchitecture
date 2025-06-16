using CSG_ADMINPRO.APLICATION.Implementation;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DATA.Configuration;
using CSG_ADMINPRO.DATA.Repository.Implementation;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using CSG_ADMINPRO.APLICATION;
using System.Data;
using CSG_ADMINPRO.DATA;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MiPoliticaCors", policy =>
    {
        policy.WithOrigins("https://localhost:7074") // Puerto de tu app MVC
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SP_Bitacora>(builder.Configuration.GetSection("StoredProcedures"));

// INYECTANDO IDbConnection
builder.Services.AddTransient<IDbConnection>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("db");
    return new SqlConnection(connectionString);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));


// INYECTANDO SERVICIOS
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IServicioService, ServicioService>();

// INYECTANDO REPOSITORIOS
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();

builder.Services.AddAutoMapper(typeof(Program));

// INYECTANDO 

// Configuración de los proveedores de registro
builder.Logging.ClearProviders(); // Limpiar proveedores existentes
builder.Logging.AddConsole();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MiPoliticaCors");
app.UseAuthorization();
app.MapControllers();
app.Run();
