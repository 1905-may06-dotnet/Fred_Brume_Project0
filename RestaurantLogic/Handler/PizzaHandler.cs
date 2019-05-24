

using System;
using System.Collections.Generic;
using PizzaBox.Data.Model;

namespace PizzaBox.Domain.Model
{
    public class PizzaHandler
    {

        public static string[] pizzaSize = { "small", "medium", "large" };
        public static string[] pizzaCrust = { "thin", "Sour dough" };

        public static List<Pizza> GetPizzas()
        {
            return new Crud().GetPizzas();
        }

         public static List<Pizza> GetPizzasFromLocation(Plocation location)
         {
            return new Crud().GetPizzasFromLocation(location);
         
         }

        public static bool validatePizzaCount(ref int maxPizza, int numPizza)
        {
            maxPizza = 100;
            return numPizza < 100 ? true : false;
        }

        public static Pizza GetPizza(int id)
        {
            return new Crud().GetPizza(id);

        }

        public static Pizza GetPizzaPrice(string pizzaType, string size, string crust)
        {
            List<Pizza> pizzas = new Crud().GetPizzas();
            Pizza piz = new Pizza();

            Console.WriteLine();

            foreach (Pizza pizza in pizzas)
            {
                //break the condition down
                if (pizza.PType.ToLower().Equals(pizzaType.ToLower()) 
                    && pizza.PSize.ToLower().Equals(size.ToLower()) && pizza.Crust.ToLower().Equals(crust.ToLower())){

                    piz = pizza;
                }
            }

            return piz;
        }


    }
}
