using System;
using CoffeeShop.EntityFramework.Services;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

namespace CoffeeShop.EntityFramework.UserInterface
{
	public class CategoryMenu
	{
        internal static void ShowCategoryMenu()
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
    }
}

