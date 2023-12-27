using System;
using RabbitMQ.Application.Interfaces.Services;
using RabbitMQ.Domain.Models;
using RabbitMQ.Infrastructure.Context;

namespace RabbitMQ.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductList()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }


        public Product AddProduct(Product product)
        {
            var result = _context.Products.Add(product);
            _context.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _context.Products.Update(product);
            _context.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var filteredData = _context.Products.Where(x => x.ProductID == Id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();
            return result != null ? true : false;
        }
    }
}

