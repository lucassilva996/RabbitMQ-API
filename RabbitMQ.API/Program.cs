using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Application.Interfaces.RabbitMQ;
using RabbitMQ.Application.Interfaces.Services;
using RabbitMQ.Application.Producer;
using RabbitMQ.Application.Services;
using RabbitMQ.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();