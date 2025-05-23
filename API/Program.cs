using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build(); // Tudo que acontece antes desse linha é serviço, tudo que acontece depois é middleware

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
