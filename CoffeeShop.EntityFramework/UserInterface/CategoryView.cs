using System;
using CoffeeShop.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.EntityFramework.UserInterface
{
    public class CategoryView
    {
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

        internal static void ShowCategory(Category category)
        {
            var panel = new Panel($"Id: {category.CategoryId}, " +
                $"Name: {category.Name}, " +
                $"Product Count: {category.Products.Count}");
            panel.Header = new PanelHeader($"{category.Name}");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            ProductView.ShowProductTable(category.Products);
            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

