using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Handler
{
    public class CustomerHandler
    {

        public static bool AddCustomer(int user_Id)
        {
            int count;

            Customer customer = new Customer
            {
                PUserId = user_Id
                
            };

            count = new Crud().AddCustomer(customer);

            if (count != 0)
            {
                return true;
            }

            return false;
        }

        public  static List<Customer> GetCustomers()
        {
            return new Crud().GetCustomers();
        }
            
    }
}
