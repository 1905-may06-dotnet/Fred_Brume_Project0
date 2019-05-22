

using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using PizzaBox.Domain.Model;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.ViewModel
{
    internal class OrderView
    {
        public static void DisplayOrder(string pizzaType, string size, string crust)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Pizza Type:  {pizzaType}");
            Console.WriteLine($"Pizza Type:  {size}");
            Console.WriteLine($"Pizza Type:  {crust}");
        }

        public static void DisplayOrderCost(double orderPizzaCost)
        {
            Console.WriteLine();
            Console.WriteLine($"Cost:  {orderPizzaCost}");
            Console.WriteLine();
        }

        public static void DisplayTotalOrderCost(double orderPizzaCost)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Total Cost:  {orderPizzaCost}");
            Console.WriteLine();
        }

        public static void DisplayOrders(List<Porder> orders)
        {
            Console.WriteLine("--------------------------------------");
            int menucount = 1;

            for (int i = 0; i <= orders.Count - 1; menucount++, i++)
            {
                Console.WriteLine($"Order:  {menucount}");
                Console.WriteLine("----------------");

                Console.WriteLine(orders[i].PUserId);
               // Puser user = UserHandler.GetUser(orders[i].PUserId + "");

               // Console.WriteLine($" Location: {user.Location}");
                Console.WriteLine($" Order Date: {orders[i].PDate}");
                Console.WriteLine($" Order Time: {orders[i].PTime}");

                Pizza pizza = PizzaHandler.GetPizza(orders[i].PizzaId);
                Console.WriteLine($" Pizza Type: {pizza.PType}");
                Console.WriteLine($" Pizza Size: {pizza.PSize}");
                Console.WriteLine($" Pizza Crust: {pizza.Crust}");

                Console.WriteLine($" ORDER PRICE: {orders[i].OrderCost}");

            }
        }
     
    }
}
