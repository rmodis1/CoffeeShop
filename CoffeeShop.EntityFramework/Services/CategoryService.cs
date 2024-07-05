using System;
using CoffeeShop.EntityFramework.Controllers;
using CoffeeShop.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.EntityFramework.Services
{
	public class CategoryService
	{
		internal static void InsertCategory()
		{
			var category = new Category();
			category.Name = AnsiConsole.Ask<string>("Category's name:");

			CategoryController.AddCategory(category);
		}

		internal static void GetCategories()
		{
			var categories = CategoryController.GetCategories();
			UserInterface.ShowCategoryTable(categories);
		}

        static internal Category GetCategoryOptionInput()
        {
            var categories = CategoryController.GetCategories();
            var categoriesArray = categories.Select(x => x.Name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Category")
                .AddChoices(categoriesArray));
            var category = categories.SingleOrDefault(x => x.Name == option);
     
            return category;
        }

        internal static void DeleteCategory()
        {
            var category = GetCategoryOptionInput();
            CategoryController.DeleteCategory(category);
        }

        internal static void UpdateCategory()
        {
            var category = GetCategoryOptionInput();

            category.Name = AnsiConsole.Confirm("Update name?") ?
                AnsiConsole.Ask<string>("What is the category's new name:")
                : category.Name;

            CategoryController.UpdateCategory(category);
        }
    }
}

