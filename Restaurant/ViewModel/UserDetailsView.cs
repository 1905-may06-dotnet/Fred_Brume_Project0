using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Client.ViewModel
{
    internal class UserDetailsView
    {

        public static void DisplayUserDetails(List<Puser> users)
         {
                Console.WriteLine("--------------------------------------");

                int menuCount = 1;

                for (int i = 0; i <= users.Count - 1; menuCount++, i++)
                {
                    Console.WriteLine($" USER ID:  {users[i].PUserId}");
                    Console.WriteLine($" FIRSTNAME:   {users[i].Firstname}");
                    Console.WriteLine($" LASTNAME:  {users[i].Lastname}");
                    Console.WriteLine($" EMAIL:  {users[i].Email}");
                    Console.WriteLine($" CITY:  {users[i].Location.City}");
                }

                Console.WriteLine();

        }
    }
}
