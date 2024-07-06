using System;
using CoffeeShop.EntityFramework.Models;
using CoffeeShop.EntityFramework.Models.DTOs;
using Spectre.Console;

namespace CoffeeShop.EntityFramework.UserInterface
{
	public class OrderView
	{
        internal static void ShowOrderTable(List<Order> orders)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Date");
            table.AddColumn("Count");
            table.AddColumn("Total Price");

            foreach (Order order in orders)
            {
                table.AddRow(
                    order.OrderId.ToString(),
                    order.CreatedDate.ToString(),
                    order.OrderProducts.Sum(product => product.Quantity).ToString(),
                    order.TotalPrice.ToString()
                    );
            }

            AnsiConsole.Write(table);
            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShowOrder(Order order)
        {
            var panel = new Panel($"Id: {order.OrderId}, " +
               $"Date: {order.CreatedDate}, " +
               $"Product Count: {order.OrderProducts.Sum(x => x.Quantity)}");
            panel.Header = new PanelHeader($"Order #: {order.OrderId}");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
        }

        internal static void ShowProductForOrderTable(List<ProductForOrderViewDTO> products)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Category");
            table.AddColumn("Price");
            table.AddColumn("Quantity");
            table.AddColumn("Total Price");

            foreach (var product in products)
            {
                table.AddRow(
                    product.Id.ToString(),
                    product.Name,
                    product.CategoryName,
                    product.Price.ToString(),
                    product.Quantity.ToString(),
                    product.TotalPrice.ToString()
                    );
            }

            AnsiConsole.Write(table);
            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

