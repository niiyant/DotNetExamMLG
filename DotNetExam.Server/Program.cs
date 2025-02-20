using DotNetExam.Business.Services;
using DotNetExam.Business.Services.Interfaces;
using DotNetExam.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.MigrationsAssembly("DotNetExam.Server")));

builder.Services.AddScoped<ITiendaService, TiendaService>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITiendaArticuloService, TiendaArticuloService>();
builder.Services.AddScoped<IClienteArticuloService, ClienteArticuloService>();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
