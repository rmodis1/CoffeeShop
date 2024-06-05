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

        static internal int GetCategoryOptionInput()
        {
            var categories = CategoryController.GetCategories();
            var categoriesArray = categories.Select(x => x.Name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Category")
                .AddChoices(categoriesArray));
            var id = categories.SingleOrDefault(x => x.Name == option).CategoryId;
     
            return id;
        }
    }
}

