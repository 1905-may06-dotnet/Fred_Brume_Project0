
using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Model
{
    public class OrderHandler
    {
           
        public static double GetOrderCost(double pizzaCost, double toppingsCost)
        {
            return pizzaCost * toppingsCost;
        }

        public static bool InsertOrders(List<Porder> orders)
        {
            bool inserted= false;
            int count = 0;

            foreach(Porder order in orders)
            {
                 count = new Crud().AddOrder(order);

                if (count != 0)
                {
                    inserted = true;
                }
            }

            List<Customer> customers = CustomerHandler.GetCustomers();

            foreach(Customer customer in customers)
            {
                if(customer.PUserId != orders[0].PUserId)
                {
                    inserted = CustomerHandler.AddCustomer(orders[0].PUserId);
                }
            }

            return inserted;
        }

        public static List<Porder> GetOrders()
        {
            return new Crud().GetOrders();
        }

        public static bool validateCurrentCost(double currentCost)
        {
            return currentCost <= 5000 ? true : false;
        }

        public static bool CheckOrderDateTime(Plocation location, Puser user)
        {
   
            List<Porder> orders = new Crud().GetOrders();

            for(int i=orders.Count -1; i >= 0; i--)
            {
                if (orders[i].PUser.PUserId == user.PUserId)  //Extract the latest Order by the user
                {
                    DateTime now = DateTime.Now;
                    DateTime datetime = DateTime.Parse(orders[i].PDate + " " + orders[i].PTime);

                    if (orders[i].CLocationId != location.LocationId) //Checks NOT Location
                    {
                        if ((now - datetime).TotalHours <= 24) //Checks within 24 hours period
                        {
                            return false;
                        }
                    }

                    if (orders[i].CLocationId == location.LocationId) //Checks YES Location
                    {
                        if ((now - datetime).TotalHours <= 2) //Checks within 2 hours period
                        {
                            return false;
                        }
                    }

                }
            }

            return true;

        }

     }
}
