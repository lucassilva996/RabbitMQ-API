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
    options.UseSqlite("Data Source=app.db"));


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

// Middleware para responder a requisições HTTP
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Banco de dados SQLite configurado com sucesso!");
});


if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();