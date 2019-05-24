using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Handler
{
    public class ToppingsHandler
    {

        public static List<Toppings> GetToppings(Pizza pizza)
        {

            List<Toppings> toppings = new Crud().GetToppings(pizza);

            return new Crud().GetToppings(pizza);
        }

        public static List<Toppings> GetDefaultToppings(Pizza pizza)
        {
           List<Toppings> toppings = new Crud().GetToppings(pizza);
           List<Toppings> defaultToppings = new List<Toppings>();

   
            foreach (Toppings topping in toppings)
           {
                if (topping.T_Type.ToLower().Trim().Equals("default"))
                {
                    defaultToppings.Add(topping);
                }
           }

            return defaultToppings;


        }

        public static List<Toppings> AddDefaultToChosenToppings(List<Toppings> chosen, List<Toppings> defaultT)
        {
            foreach(Toppings topping in defaultT)
            {
                chosen.Add(topping);
            }

            return chosen;
        }

        public static bool validateToppingsCount(ref int maxTopping, int numTopping)
        {
            maxTopping = 100;
            return numTopping < 100 ? true : false;
        }

        public static double TotalToppingsCost(List<Toppings> toppings)
        {
            double total = 0;

            foreach (Toppings topping in toppings)
            {
                total += Convert.ToDouble(topping.Cost);  
            }

            return total;
        }
    }
}
