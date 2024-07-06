using System;
using CoffeeShop.EntityFramework.Services;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

namespace CoffeeShop.EntityFramework.UserInterface
{
	public class OrderMenu
	{
        internal static void ShowOrderMenu()
        {
            bool isOrderMenuRunning = true;
            while (isOrderMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<OrdersMenu>()
                .Title("Orders Menu")
                .AddChoices(
                    OrdersMenu.AddOrder,
                    OrdersMenu.GetOrders,
                    OrdersMenu.GetOrder,
                    OrdersMenu.GoBack));

                switch (option)
                {
                    case OrdersMenu.AddOrder:
                        OrderService.InsertOrder();
                        break;
                    case OrdersMenu.GetOrders:
                        OrderService.GetOrders();
                        break;
                    case OrdersMenu.GetOrder:
                        OrderService.GetOrder();
                        break;
                    case OrdersMenu.GoBack:
                        isOrderMenuRunning = false;
                        break;
                }
            }
        }
    }
}

