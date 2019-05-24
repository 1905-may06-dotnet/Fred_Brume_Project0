using PizzaBox.Data.Model;

using System;
using System.Collections.Generic;

namespace PizzaBox.Client.ViewModel
{
    internal class ToppingView : BaseView
    {
        internal static void DisplayToppings(List<Toppings> toppings)
        {
            Console.WriteLine(" CHOSEN TOPPINGS");
            Console.WriteLine("-----------------------------------------");

            int menucount = 1;

            for (int i = 0; i <= toppings.Count - 1; menucount++, i++)
            {
                Console.WriteLine($" ({menucount} )\t  {toppings[i].TName} \t {toppings[i].Cost}");
            }
        }

        internal static void DisplayDefaultToppings(List<Toppings> toppings)
        {
            Console.WriteLine(" DEFAULT TOPPINGS: ");

            for (int i = 0; i <= toppings.Count - 1; i++)
            {
                Console.Write($" [ {toppings[i].TName} ]  ");
            }

            Console.WriteLine();
        }

        internal static void DisplayToppingsTotalCost(double cost)
        {
            Console.WriteLine(" Total Toppings Cost: "  + cost);
        }


    }
}
