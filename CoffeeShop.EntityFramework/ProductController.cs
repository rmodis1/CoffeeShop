using System;
using Spectre.Console;

namespace CoffeeShop.EntityFramework
{
	public class ProductController
	{
		public ProductController()
		{
		}

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
            var product = db.Products.SingleOrDefault(x => x.Id == id);

            return product;
        }

        internal static List<Product> ViewAllProducts()
        {
            using var db = new ProductContext();
            var products = db.Products.ToList();
            return products;
        }
    }
}

