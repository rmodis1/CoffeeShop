using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.EntityFramework.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string Name { get; set; }

		public List<Product> Products { get; set; }

	}
}

