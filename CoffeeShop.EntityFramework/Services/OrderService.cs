using System;
using CoffeeShop.EntityFramework.Controllers;
using CoffeeShop.EntityFramework.Models;
using CoffeeShop.EntityFramework.Models.DTOs;
using CoffeeShop.EntityFramework.UserInterface;
using Spectre.Console;

namespace CoffeeShop.EntityFramework.Services
{
	public class OrderService
	{
        internal static void InsertOrder()
        {
            var orderProducts = GetProductsForOrder();

            OrderController.AddOrder(orderProducts);
        }

        private static List<OrderProduct> GetProductsForOrder()
        {
            var products = new List<OrderProduct>();
            var order = new Order
            {
                CreatedDate = DateTime.Now
            };

            bool isOrderFinished = false;
            while (!isOrderFinished)
            {
                var product = ProductService.GetProductOptionInput();
                var quantity = AnsiConsole.Ask<int>("How many?");

                order.TotalPrice = order.TotalPrice + (quantity * product.Price);

                products.Add(
                    new OrderProduct
                    {
                        Order = order,
                        ProductId = product.ProductId,
                        Quantity = quantity
                    });
                isOrderFinished = !AnsiConsole.Confirm("Would you like to add " +
                    "more products?");
            }
            return products;
        }

        internal static void GetOrders()
        {
            var orders = OrderController.GetOrders();

            OrderView.ShowOrderTable(orders);
        }

        internal static void GetOrder()
        {
            var order = GetOrderOptionInput();
            var products = order.OrderProducts
                .Select(x => new ProductForOrderViewDTO
                {
                    Id = x.ProductId,
                    Name = x.Product.Name,
                    CategoryName = x.Product.Category.Name,
                    Quantity = x.Quantity,
                    Price = x.Product.Price,
                    TotalPrice = x.Quantity * x.Product.Price
                }).ToList();

            OrderView.ShowOrder(order);
            OrderView.ShowProductForOrderTable(products);
        }

        private static Order GetOrderOptionInput()
        {
            var orders = OrderController.GetOrders();

            var ordersArray = orders.Select(order => $"{order.OrderId}.{order.CreatedDate} - " +
            $"{order.TotalPrice}").ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Order")
                .AddChoices(ordersArray));
            var id = option.Split('.');
            var order = orders.SingleOrDefault(order =>
                order.OrderId == int.Parse(id[0]));

            return order;
        }
    }
}

