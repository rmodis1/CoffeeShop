using System;
namespace CoffeeShop.EntityFramework
{
	public class Enums
	{
        internal enum MainMenuOptions
        {
            ManageCategories,
            ManageProducts,
            ManageOrders,
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

        internal enum OrdersMenu
        {
            AddOrder,
            GetOrders,
            GetOrder,
            GoBack
        }
    }
}

