using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Entities;
using System.Data.Entity;

namespace Example
{
    public class SomeService
    {
        public void DoSmth()
        {
            using (var context = new AppDbContext())
            {
                var info = context.Customers
                    .Include(c => c.Orders.Select(o => o.OrderItems.Select(oi => oi.Item)))
                    .ToList();

                this.PrintCustomers(info);
            }
        }

        private void PrintCustomers(List<Customer> customers)
        {
            Console.WriteLine($"Customers number: {customers.Count}");

            foreach (var customer in customers)
            {
                Console.WriteLine($"\nCust. No. {customer.Id}:");
                Console.WriteLine($"Cust. Name: {customer.Name}\nCust. Address: {customer.Address}\n" +
                    $"Cust. City: {customer.City}\nCust. State: {customer.State}");
                this.PrintOrders(customer.Orders.ToList());
            }
        }

        private void PrintOrders(List<Order> orders)
        {
            Console.WriteLine($"Orders number: {orders.Count}");

            foreach (var order in orders)
            {
                Console.WriteLine($"Invoice No.: {order.Id}\nDate: {order.Date}");
                Console.WriteLine("Order items:");

                PrintItems(order.OrderItems.ToList());
            }
        }

        private void PrintItems(List<OrderItem> orderItems)
        {
            Console.WriteLine($"Items number: {orderItems.Count}");

            foreach (var orderItem in orderItems)
            {
                Console.WriteLine($"Description: {orderItem.Item.Description}\n" +
                    $"Price: {orderItem.Item.Price}\n" +
                    $"Quantity: {orderItem.Quantity}");
            }
        }
    }
}