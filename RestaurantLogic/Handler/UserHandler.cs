using PizzaBox.Data.Model;
using RestaurantLogic;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Handler
{
    public class UserHandler
    {
        public static Puser GetUser(string username)
        {
            return new Crud().GetUser(username);
        }

       public static Puser ValidateUser(string username, string password)
        {

            Puser user = GetUser(username);

            if (user != null && user.PPassword.Equals(password))
            {
                return user;
            }

            return null;

        }

        public static bool InsertUser(string firstName, string lastName, string username, 
            string password, string email, string street, string city, string state, string zipcode)
        {

            bool inserted = LocationHandler.InsertLocation(street, city, state, zipcode);

           List<Plocation>  locations=LocationHandler.GetLocationData();

            if(inserted == true)
            {
                Puser user = new Puser
                {
                    Firstname = firstName,
                    Lastname = lastName,
                    Username = username,
                    PPassword = password,
                    Email = email,
                    LocationId = locations[locations.Count - 1].LocationId
                };

                int icount = new Crud().AddUser(user);

                if(icount == 0)
                {
                    return false;
                }
            }else
            {
                return false;
            }

            return true;
        }

        public static List<Puser> GetUsers()
        {
            return new Crud().GetUsers();
        }

        public static bool CheckIfEmployee(Puser user)
        {    
            return new Crud().GetEmployee(user) != null ? true : false; 
        }
    }
}
