using Microsoft.EntityFrameworkCore;
using RabbitMQ.Domain.Models;

namespace RabbitMQ.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
            public DbSet<Product> Produtos { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db");

    }
}
