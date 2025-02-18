using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
    //using Microsoft.Extensions.DependencyInjection;
    //using VentasApp.Application;
    //using VentasApp;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VentasApp.Application.Services;
using System.Reflection;
using VentasApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();           // builder.Services.AddRazorComponents();
builder.Services.AddServerSideBlazor();     // Registrar las páginas y componentes de Blazor. Para Blazor Server.

var connectionString = builder.Configuration.GetConnectionString("VentasDbConnection");             // Acceder a la cadena de conexión que has definido en appsettings.json.

builder.Services.AddDbContext<VentasDbContext>(options => options.UseSqlServer(connectionString));  // Registrar el DbContext en el contenedor de dependencias.

// Configurar MediatR para buscar los handlers y manejar los comandos y consultas
// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());          // MediatR buscará los handlers dentro del ensamblado de la clase Program. RegisterServicesFromAssemblyContaining<Program>() busca automáticamente los handlers en el ensamblado donde resides los archivos de comandos, consultas y eventos (en este caso, el archivo Program.cs).

// Agregar servicios relacionados con componentes interactivos

builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<VentaService>();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddTransient<IProductoService, ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
