using System;
using CoffeeShop.EntityFramework.Models;

namespace CoffeeShop.EntityFramework.Controllers
{
	public class OrderController
	{
        internal static void AddOrder(List<OrderProduct> orders)
        {
            using var db = new ProductContext();
            db.OrderProducts.AddRange(orders);
            db.SaveChanges();
        }
    }
}

