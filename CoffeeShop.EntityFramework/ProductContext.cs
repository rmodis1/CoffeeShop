using System;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EntityFramework
{
	public class ProductContext: DbContext
	{
		public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source = products.db");
    }
}

