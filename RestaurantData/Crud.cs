using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Data.Model
{
    public class Crud : ICrud
    {

        public int AddLocation(Plocation location)
        {
            int i = 0;

            try
            {
                DBinstance.Instance.Add(location);
                i = DBinstance.Instance.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();

            }
            catch(Exception e)
            {
                Console.WriteLine("Couldn't Insert LOCATION: ");
                Console.WriteLine(e);
                Console.WriteLine();
            }
          

           return i;

        }

        public Plocation GetLocation(int location_Id)
        {
            return null;
        }

        public List<Plocation> GetLocations()
        {
           return DBinstance.Instance.Plocation.ToList();
        }

        public void voidDeleteLocation(Plocation location)
        {

        }

        public Pizza GetPizza(int pizza_Id)
        {
            return GetPizzas().Where<Pizza>(r => r.PizzaId == pizza_Id).FirstOrDefault();
        }

        public List<Pizza> GetDistinctPizzas()
        {
            return DBinstance.Instance.Pizza.GroupBy(a => a.PType)
                   .Select(g => g.First())
                   .ToList();
        }

        public List<Pizza> GetPizzas()
        {
            return DBinstance.Instance.Pizza.ToList();
        }

        public List<Pizza> GetPizzasFromLocation(Plocation location)
        {
            //if it is distinct by name, you can get an exception. This logic is not feasible
            return GetDistinctPizzas().Where<Pizza>(r => r.SLocationId == location.LocationId).ToList();   
        }



        public List<Toppings> GetTopping(Pizza pizza)
        {
            return null;
        }

        public List<Toppings> GetToppings(Pizza pizza)
        {
            List<Toppings> toppings = null;
            try
            {
              toppings = GetToppings().Where<Toppings>(p => p.PizzaId == pizza.PizzaId).ToList();

            }
            catch(Exception e)
            {
                Console.WriteLine("Could not get data from the database");
            }

            return toppings;
            
        }


        public Toppings GetTopping(int pizza_Id)
        {
            throw new NotImplementedException();
        }

        public List<Toppings> GetToppings()
        {
            return DBinstance.Instance.Toppings.ToList();
        }

        public List<Puser> GetUsers()
        {
            return DBinstance.Instance.Puser.ToList();
        }

        public Puser GetUser(string  username)
        {
            return GetUsers().Where<Puser>(u =>  u.Username == username).FirstOrDefault();
        }

        public Employee GetEmployee(Puser user)
        {
            return GetEmployees().Where<Employee>(e => e.PUserId == user.PUserId).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return DBinstance.Instance.Employee.ToList();
        }

        public int AddUser(Puser user)
        {
            int i = 0;
            try { 

                DBinstance.Instance.Add(user);
                i = DBinstance.Instance.SaveChanges();
            }  
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert USER: ");
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }

        public int AddOrder(Porder order)
        {
            int i = 0;
            try
            {

                DBinstance.Instance.Add(order);
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert USER: ");
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }

        public List<Porder> GetOrders()
        {
            return DBinstance.Instance.Porder.ToList();
        }

        public int AddCustomer(Customer customer)
        {

            int i = 0;
            try
            {
                DBinstance.Instance.Add(customer);
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert USER: " + e);
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }

        public List<Customer> GetCustomers()
        {
            return DBinstance.Instance.Customer.ToList();
        }
    }
}
