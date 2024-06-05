using System;
using CoffeeShop.EntityFramework.Models;
using CoffeeShop.EntityFramework.Services;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

namespace CoffeeShop.EntityFramework
{
	public class UserInterface
	{
        static internal void MainMenu()
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What woud you like to do?")
                .AddChoices(
                    MenuOptions.AddCategory,
                    MenuOptions.ViewAllCategories,
                    MenuOptions.AddProduct,
                    MenuOptions.DeleteProduct,
                    MenuOptions.UpdateProduct,
                    MenuOptions.ViewAllProducts,
                    MenuOptions.ViewProduct));

                switch (option)
                {
                    case MenuOptions.AddCategory:
                        CategoryService.InsertCategory();
                        break;
                    case MenuOptions.ViewAllCategories:
                        CategoryService.GetCategories();
                        break;
                    case MenuOptions.AddProduct:
                        ProductService.InsertProduct();
                        break;
                    case MenuOptions.DeleteProduct:
                        ProductService.DeleteProduct();
                        break;
                    case MenuOptions.UpdateProduct:
                        ProductService.UpdateProduct();
                        break;
                    case MenuOptions.ViewProduct:
                        ProductService.GetProduct();
                        break;
                    case MenuOptions.ViewAllProducts:
                        ProductService.GetProducts();
                        break;
                }
            }
        }

		internal static void ShowProductTable(List<Product> products)
		{
			var table = new Table();
			table.AddColumn("Id");
			table.AddColumn("Name");
			table.AddColumn("Price");
            table.AddColumn("Category");

			foreach (var product in products)
			{
				table.AddRow(
					product.ProductId.ToString(),
					product.Name,
					product.Price.ToString(),
                    product.Category.Name
                    );
                    
			}

			AnsiConsole.Write(table);
			Console.WriteLine("Enter any key to continue");
			Console.ReadLine();
			Console.Clear();
		}

        internal static void ShowProduct(Product product)
        {
			var panel = new Panel($"Id: {product.ProductId}, " +
				$"Name: {product.Name}" +
                $"Category: {product.Category.Name}");
			panel.Header = new PanelHeader("Product Info");
			panel.Padding = new Padding(2, 2, 2, 2);

			AnsiConsole.Write(panel);

            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShowCategoryTable(List<Category> categories)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");

            foreach (var category in categories)
            {
                table.AddRow(
                    category.CategoryId.ToString(),
                    category.Name
                    );
            }

            AnsiConsole.Write(table);
            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
	}
}

