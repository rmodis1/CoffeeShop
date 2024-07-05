using System;
using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EntityFramework
{
	public class ProductContext: DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite($"Data Source = products.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
				.HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId });

			modelBuilder.Entity<OrderProduct>()
				.HasOne(orderProduct => orderProduct.Order)
				.WithMany(order => order.OrderProducts)
				.HasForeignKey(orderProduct => orderProduct.OrderId);

			modelBuilder.Entity<OrderProduct>()
				.HasOne(orderProduct => orderProduct.Product)
				.WithMany(order => order.OrderProducts)
				.HasForeignKey(orderProduct => orderProduct.ProductId);

			modelBuilder.Entity<Product>()
				.HasOne(product => product.Category)
				.WithMany(order => order.Products)
				.HasForeignKey(product => product.CategoryId);

        }
    }
}

