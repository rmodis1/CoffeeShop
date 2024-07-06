using System;
using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

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

        internal static List<Order> GetOrders()
        {
            using var db = new ProductContext();

            var ordersList = db.Orders
                .Include(order => order.OrderProducts)
                .ThenInclude(orderProduct => orderProduct.Product)
                .ThenInclude(product => product.Category)
                .ToList();

            return ordersList;
        }
    }
}

