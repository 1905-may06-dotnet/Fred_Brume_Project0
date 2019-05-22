using PizzaBox.Data;
using PizzaBox.Data.Model;
using System.Collections.Generic;


namespace RestaurantLogic
{
    public class LocationHandler
    {
       public static List<Plocation> GetLocationData()
        {
           List<Plocation> plocation = new Crud().GetLocations();

           return plocation;     
        }

        public static bool InsertLocation(string street, string city, string state, string zipcode)
        {

            Plocation location = new Plocation();

            location.Street = street;
            location.City = city;
            location.PState = state;
            location.Zipcode = zipcode;

            int count = new Crud().AddLocation(location);

            if(count != 0)
            {
                return true;
            }

            return false;
        }

    }
}

