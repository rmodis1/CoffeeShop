using System;
using Spectre.Console;

namespace CoffeeShop.EntityFramework.UserInterface
{
	public class ProductView
	{

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
                $"Name: {product.Name}, " +
                $"Category: {product.Category.Name}");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }	
}

