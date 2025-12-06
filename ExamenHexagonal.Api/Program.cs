using ExamenHexagonal.Application.Services;
using ExamenHexagonal.Domain.Ports.In;
using ExamenHexagonal.Domain.Ports.Out;
using ExamenHexagonal.Infrastructure.Persistence;
using ExamenHexagonal.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // 👈 IMPORTANTE

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 👇 AQUÍ cambiamos AutoDetect por una versión fija de MySQL
var serverVersion = new MySqlServerVersion(new Version(8, 0, 40)); // Ajusta si tu MySQL es 8.x

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Hexagonal DI
builder.Services.AddScoped<IUsuarioRepositoryPort, UsuarioRepositoryAdapter>();
builder.Services.AddScoped<IProyectoRepositoryPort, ProyectoRepositoryAdapter>();

builder.Services.AddScoped<IUsuarioUseCase, UsuarioService>();
builder.Services.AddScoped<IProyectoUseCase, ProyectoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
