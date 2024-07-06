using System;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

namespace CoffeeShop.EntityFramework.UserInterface
{
    public class MainMenu
    {
        static internal void ShowMainMenu()
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
                        CategoryMenu.ShowCategoryMenu();
                        break;
                    case MainMenuOptions.ManageProducts:
                        ProductMenu.ShowProductMenu();
                        break;
                    case MainMenuOptions.ManageOrders:
                        OrderMenu.ShowOrderMenu();
                        break;
                    case MainMenuOptions.Quit:
                        Console.WriteLine("Goodbye");
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}

