using BlogTecorp.Application.Services;
using BlogTecorp.Domain.Interfaces;
using BlogTecorp.Infrastructure.Persistence.Contexts;
using BlogTecorp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 1. Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configurar Base de Datos
builder.Services.AddDbContext<BlogTecorpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Inyección de Dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();
// (Aquí también mantienes la inyección de ProductRepository y ProductService)

var app = builder.Build();

// 4. Habilitar Swagger en el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogTecorp API v1");
        c.RoutePrefix = string.Empty; // Hace que Swagger se abra en la raíz (localhost:puerto/)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();