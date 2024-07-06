using System;
using CoffeeShop.EntityFramework.Models;
using CoffeeShop.EntityFramework.Models.DTOs;
using CoffeeShop.EntityFramework.Services;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

namespace CoffeeShop.EntityFramework.UserInterface
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
                new SelectionPrompt<MainMenuOptions>()
                .Title("What woud you like to do?")
                .AddChoices(
                    MainMenuOptions.ManageCategories,
                    MainMenuOptions.ManageProducts,
                    MainMenuOptions.ManageOrders,
                    MainMenuOptions.Quit));

                switch (option)
                {
                    case MainMenuOptions.ManageCategories:
                        CategoryMenu();
                        break;
                    case MainMenuOptions.ManageProducts:
                        ProductMenu();
                        break;
                    case MainMenuOptions.ManageOrders:
                        OrderMenu();
                        break;
                    case MainMenuOptions.Quit:
                        Console.WriteLine("Goodbye");
                        isAppRunning = false;
                        break;
                }
            }
        }

        internal static void CategoryMenu()
        {
            bool isCategoriesMenuRunning = true;
            while (isCategoriesMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoriesMenu>()
                .Title("Categories Menu")
                .AddChoices(
                    CategoriesMenu.AddCategory,
                    CategoriesMenu.DeleteCategory,
                    CategoriesMenu.UpdateCategory,
                    CategoriesMenu.ViewCategory,
                    CategoriesMenu.ViewAllCategories,
                    CategoriesMenu.GoBack));

                switch (option)
                {
                    case CategoriesMenu.AddCategory:
                        CategoryService.InsertCategory();
                        break;
                    case CategoriesMenu.DeleteCategory:
                        CategoryService.DeleteCategory();
                        break;
                    case CategoriesMenu.UpdateCategory:
                        CategoryService.UpdateCategory();
                        break;
                    case CategoriesMenu.ViewCategory:
                        CategoryService.GetCategory();
                        break;
                    case CategoriesMenu.ViewAllCategories:
                        CategoryService.GetCategories();
                        break;
                    case CategoriesMenu.GoBack:
                        isCategoriesMenuRunning = false;
                        break;
                }
            }
        }

        internal static void ProductMenu()
        {
                bool isProductsMenuRunning = true;
                while (isProductsMenuRunning)
                {
                    Console.Clear();
                    var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ProductsMenu>()
                    .Title("Products Menu")
                    .AddChoices(
                        ProductsMenu.AddProduct,
                        ProductsMenu.DeleteProduct,
                        ProductsMenu.UpdateProduct,
                        ProductsMenu.ViewProduct,
                        ProductsMenu.ViewAllProducts,
                        ProductsMenu.GoBack));

                switch (option)
                {
                    case ProductsMenu.AddProduct:
                        ProductService.InsertProduct();
                        break;
                    case ProductsMenu.DeleteProduct:
                        ProductService.DeleteProduct();
                        break;
                    case ProductsMenu.UpdateProduct:
                        ProductService.UpdateProduct();
                        break;
                    case ProductsMenu.ViewProduct:
                        ProductService.GetProduct();
                        break;
                    case ProductsMenu.ViewAllProducts:
                        ProductService.GetProducts();
                        break;
                    case ProductsMenu.GoBack:
                        isProductsMenuRunning = false;
                        break;
                }
            }
        }

        internal static void OrderMenu()
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

