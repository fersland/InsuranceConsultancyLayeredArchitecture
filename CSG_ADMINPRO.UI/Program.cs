using CSG_ADMINPRO.APLICATION.Implementation;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DATA.Repository.Implementation;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.UI.Services.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configurar lectura de appsettings.json
var configuration = builder.Configuration;

// Inyectar HttpClient con la URL base de la API desde configuración
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
});


// Nuevo servicio que llama a la API
builder.Services.AddScoped<IClienteApiService, ClienteApiService>();

// Agregar controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configurar pipeline de ejecución
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
