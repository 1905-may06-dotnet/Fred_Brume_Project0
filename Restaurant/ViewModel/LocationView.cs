
using PizzaBox.Data.Model;
using PizzaBox.Domain.Model;
using RestaurantLogic;
using System;
using System.Collections.Generic;


namespace PizzaBox.Client.ViewModel
{
    public class LocationView : BaseView
    { 
        internal static void DisplayLocationsOptions(List<Plocation> locations)
        {
           Console.WriteLine("================== LOCATIONS ======================");
           Console.WriteLine();
           Console.WriteLine("Choose from the Locations below:");

          int menuCount = 1;
            for (int i=0; i < locations.Count; menuCount++, ++i){

                Console.WriteLine();
                Console.WriteLine($"  {menuCount}  -  STREET: {locations[i].Street}   CITY: " +
                    $"{locations[i].Street}   STATE: {locations[i].PState}   ZIPCODE: {locations[i].Zipcode} ");
            }

        }

        internal static void DisplayLocation(List<Plocation> locations, int index)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Location: {index}");
            Console.WriteLine($"Street: {locations[index].Street}");
            Console.WriteLine($"City: {locations[index].City}");
            Console.WriteLine($"State: {locations[index].PState}");
            Console.WriteLine($"Zipcode: {locations[index].Zipcode}");

        }


    }
}
