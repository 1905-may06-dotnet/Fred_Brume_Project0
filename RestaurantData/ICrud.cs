using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Data
{
    public interface ICrud {

       List<Plocation> GetLocations();

        Plocation GetLocation(int location_Id);
        int AddLocation(Plocation location);
        void voidDeleteLocation(Plocation location);

        List<Pizza> GetPizzas();
        Pizza GetPizza(int pizza_Id);
        List<Pizza> GetPizzasFromLocation(Plocation location);

        List<Toppings> GetToppings(Pizza pizza);
        Toppings GetTopping(int pizza_Id);

        List<Puser> GetUsers();
        Puser GetUser(string username);

        int AddUser(Puser user);

        Employee GetEmployee(Puser user);

        List<Employee> GetEmployees();

        int AddOrder(Porder order);

        List<Porder> GetOrders();

        List<Customer> GetCustomers();
        int AddCustomer(Customer customer);



    }
}
