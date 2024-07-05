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
                    OrdersMenu.GoBack));

                switch (option)
                {
                    case OrdersMenu.AddOrder:
                        OrderService.InsertOrder();
                        break;
                    case OrdersMenu.GoBack:
                        isOrderMenuRunning = false;
                        break;
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
				$"Name: {product.Name}, " +
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

        internal static void ShowCategory(Category category)
        {
            var panel = new Panel($"Id: {category.CategoryId}, " +
                $"Name: {category.Name}, " +
                $"Product Count: {category.Products.Count}");
            panel.Header = new PanelHeader($"{category.Name}");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            ShowProductTable(category.Products);
            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

