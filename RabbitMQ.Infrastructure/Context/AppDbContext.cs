using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Domain.Models;

namespace RabbitMQ.Infrastructure.Context
{
	public class AppDbContext : DbContext
	{
		protected readonly IConfiguration Configuration;
		public AppDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
		}

		public DbSet<Product> Products { get; set; }
    }
}

