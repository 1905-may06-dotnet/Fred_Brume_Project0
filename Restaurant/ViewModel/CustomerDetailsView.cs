using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Client.ViewModel
{
    internal class CustomerDetailsView
    {
        public static void DisplayCustomerDetails(List<Customer> customers)
        {
            Console.WriteLine("--------------------------------------");

            int menuCount = 1;

            for (int i = 0; i <= customers.Count - 1; menuCount++, i++)
            {
                Console.WriteLine($" CUSTOMER ID:  {customers[i].PUser.PUserId}");
                Console.WriteLine($" FIRSTNAME:   {customers[i].PUser.Firstname}");
                Console.WriteLine($" LASTNAME:  {customers[i].PUser.Lastname}");
                Console.WriteLine($" EMAIL:  {customers[i].PUser.Email}");
                Console.WriteLine($" CITY:  {customers[i].PUser.Location.City}");
            }

            Console.WriteLine();
        }
    }
}
