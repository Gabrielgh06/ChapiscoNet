using API.Middleware;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Config;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProductsRepository, ProductRepository>(); // Registrando o repositório de produtos
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // Registrando o repositório genérico
builder.Services.AddCors();

var app = builder.Build(); // Tudo que acontece antes desse linha é serviço, tudo que acontece depois é middleware

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200")); //podemos enviar solicitações ao nosso servidor de API desde que venham dessa origem (http e https - 4200)

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync(); // Aplica as migrações pendentes ao banco de dados
    await StoreContextSeed.SeedAsync(context); // Popula o banco de dados com dados iniciais
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
