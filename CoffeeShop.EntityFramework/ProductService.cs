using System;
using Spectre.Console;

namespace CoffeeShop.EntityFramework
{
	public class ProductService
	{
		internal static void InsertProduct()
		{
            string name = AnsiConsole.Ask<string>("Product's name:");
            ProductController.AddProduct(name);
        }

		internal static void DeleteProduct()
		{
			var product = GetProductOptionInput();
			ProductController.DeleteProduct(product);
		}

		static internal Product GetProductOptionInput()
		{
			var products = ProductController.ViewAllProducts();
			var productsArray = products.Select(x => x.Name).ToArray();

			var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose Product")
				.AddChoices(productsArray));
			var id = products.SingleOrDefault(x => x.Name == option).Id;
			var product = ProductController.ViewProduct(id);

			return product;
		}

		internal static void GetProduct()
		{
            var product = GetProductOptionInput();
            UserInterface.ShowProduct(product);
        }

		internal static void GetProducts()
		{
            var products = ProductController.ViewAllProducts();
            UserInterface.ShowProductTable(products);
        }

		internal static void UpdateProduct()
		{
			var product = GetProductOptionInput();
			product.Name = AnsiConsole.Ask<string>("What is the product's new name:");
			ProductController.UpdateProduct(product);
		}
	}
}

