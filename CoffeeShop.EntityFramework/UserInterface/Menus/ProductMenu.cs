using System;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

namespace CoffeeShop.EntityFramework.UserInterface
{
    public class ProductMenu
    {
        internal static void ShowProductMenu()
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
    }
}

