using Core.Security;
using Kodlama.io.Devs.Application;
using Kodlama.io.Devs.Infrastructure;
using Kodlama.io.Devs.Persistence;
using Kodlama.io.Devs.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(); // Extension method from Kodlama.io.Devs.Application
builder.Services.AddInfrastructureServices(); // Extension method from Kodlama.io.Devs.Infrastructure
builder.Services.AddPersistenceServices(builder.Configuration); // Extension method from Kodlama.io.Devs.Persistence

builder.Services.AddSecurityServices(); // Extension method from Core.Application

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenServices(); // Extension method from WebAPI>Extensions

builder.Services.AddJwtBearerServices(builder.Configuration); // Extension method from WebAPI>Extensions

builder.Services.AddHttpClientServices(); // Extension method from WebAPI>Extensions

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
