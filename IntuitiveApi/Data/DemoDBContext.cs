using System;
using IntuitiveApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IntuitiveApi.Data
{
    public class DemoDBContext:DbContext
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
