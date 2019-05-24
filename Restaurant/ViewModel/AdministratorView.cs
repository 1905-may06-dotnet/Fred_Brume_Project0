
using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using PizzaBox.Domain.Model;
using RestaurantLogic;
using System;
using System.Collections.Generic;


namespace PizzaBox.Client.ViewModel
{
    internal class AdministratorView : BaseView, IUserView
    {

        private Puser user;
        public void displayView(Puser user)
        {
            this.user = user;

            Console.WriteLine("===================== ADMINISTRATOR ==================");
            Console.WriteLine();
            Console.WriteLine($"Choose from the options below from 1 to {menuAdmin.Length}");
            Console.WriteLine();

            int listCount = 1;
            int option;


            for (int i = 0; i < menuAdmin.Length - 1; listCount++, i++)
            {
                Console.WriteLine($" ({listCount}) \t {menuAdmin[i]}");
            }

            Console.WriteLine();

            do
            {
                option = base.GetValidatedOption(menuAdmin.Length - 1);

            } while (option == -1);

            //Load Locations from domainusing
            List<Plocation> locations = LocationHandler.GetLocationData();

            switch (option - 1)
            {
                case (int)menuAdminConst.Stores:
                    {
                        LocationView.DisplayLocationsOptions(locations);

                        break;
                    }

                case (int)menuAdminConst.Pizzas:
                    {

                        LocationView.DisplayLocationsOptions(locations);

                        do
                        {
                            option = base.GetValidatedOption(locations.Count - 1);

                        } while (option == -1);

                        //Load Pizzas from domain
                        List<Pizza> pizzas = PizzaHandler.GetPizzasFromLocation(locations[option - 1]);

                        //Display pizzas
                        PizzaView.DisplayPizzas(pizzas);

                        break;
                    }

                case (int)menuAdminConst.Order:

                    {
                        List<Porder> orders = OrderHandler.GetOrders();
                        OrderView.DisplayOrders(orders);

                        break;
                    }
                case (int)menuAdminConst.Customer:

                    {
                        List<Customer> customers = CustomerHandler.GetCustomers();
                        CustomerDetailsView.DisplayCustomerDetails(customers);

                        break;
                    }
                case (int)menuAdminConst.Sales:

                    {

                        break;
                    }
                case (int)menuAdminConst.Users:
                    {
                        List<Puser> users = UserHandler.GetUsers();
                        UserDetailsView.DisplayUserDetails(users);

                        break;
                    }

            }

            string option1;

            do
            {
                option1 = base.GetInput("Type in YES to continue or NO to quit. ");

                if (option1.ToLower().Equals("yes"))
                {
                    displayView(user);
                }
                else if (option1.ToLower().Equals("no"))
                {
                    Console.WriteLine("Thank you for choosing PizaBox");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Incorrect Option, pls try again.");
                    Console.WriteLine();
                }

            } while (option1.ToLower().Equals("yes") || option1.ToLower().Equals("no"));

            Console.WriteLine();

        }
    }
}
