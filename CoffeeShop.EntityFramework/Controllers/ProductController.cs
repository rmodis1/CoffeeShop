using System;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace CoffeeShop.EntityFramework
{
	public class ProductController
	{

        internal static void AddProduct(Product product)
        {
            using var db = new ProductContext();
            db.Add(product);
            db.SaveChanges();
        }

        internal static void DeleteProduct(Product product)
        {
            using var db = new ProductContext();
            db.Remove(product);
            db.SaveChanges();
        }

        internal static void UpdateProduct(Product product)
        {
            using var db = new ProductContext();
            db.Update(product);
            db.SaveChanges();
        }

        internal static Product ViewProduct(int id)
        {
            using var db = new ProductContext();
            var product = db.Products
                .Include(x => x.Category)
                .SingleOrDefault(x => x.ProductId == id);

            return product;
        }

        internal static List<Product> ViewAllProducts()
        {
            using var db = new ProductContext();
            var products = db.Products
                .Include(x => x.Category)
                .ToList();

            return products;
        }
    }
}

