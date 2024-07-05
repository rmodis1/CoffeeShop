using System;
namespace CoffeeShop.EntityFramework
{
	public class Enums
	{
        internal enum MainMenuOptions
        {
            ManageCategories,
            ManageProducts,
            Quit
        }

        internal enum CategoriesMenu
        {
            AddCategory,
            DeleteCategory,
            UpdateCategory,
            ViewCategory,
            ViewAllCategories,
            GoBack
        }

        internal enum ProductsMenu
        {
            AddProduct,
            DeleteProduct,
            UpdateProduct,
            ViewProduct,
            ViewAllProducts,
            GoBack
        }
    }
}

