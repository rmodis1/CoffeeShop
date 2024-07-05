﻿using System;
using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EntityFramework
{
	public class ProductContext: DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite($"Data Source = products.db");
    }
}

