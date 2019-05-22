

using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using System;


namespace PizzaBox.Client.ViewModel
{

    internal class MainView : BaseView
    {

        private static bool isEmployee;
      
        private static void DisplayMainOption(Puser user)
        {
            if (isEmployee)
            {
                IUserView userView = new AdministratorView();  //Polymorphism
                userView.displayView(user);
            }else
            {
                IUserView userView = new CustomerView();         //Polymorphism
                userView.displayView(user);
            }
        }

        internal static void DisplayUserDetails(Puser user)
        {
            isEmployee = UserHandler.CheckIfEmployee(user);
            string userType = isEmployee ? "Customer" : "Employee";

            Console.WriteLine();
            Console.WriteLine($" First Name: {user.Firstname}");
            Console.WriteLine($" Last Name: {user.Lastname}");
            Console.WriteLine($" Email: {user.Email}");
            Console.WriteLine($" User Type: {userType}");

            DisplayMainOption(user);
        }

    }
}
