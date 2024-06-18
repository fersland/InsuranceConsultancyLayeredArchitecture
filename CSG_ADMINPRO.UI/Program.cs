using CSG_ADMINPRO.DATA.Configuration;
using CSG_ADMINPRO.DATA.Repository.Implementation;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.APLICATION.Implementation;
using CSG_ADMINPRO.APLICATION.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDbConnection>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("db");
    return new SqlConnection(connectionString);
});

builder.Services.AddHttpClient();

// Configurar la inyeccion de la lista de SP disponibles
builder.Services.Configure<SP_Bitacora>(builder.Configuration.GetSection("StoredProcedures"));

// Configurar la inyeccion a los servicios
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<IAseguradoService, AseguradoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<ICitaService, CitaService>();

// Configurar la inyeccion a los repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<IAseguradoRepository, AseguradoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
