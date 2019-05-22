using PizzaBox.Data.Model;
using PizzaBox.Domain.Model;
using System;
using System.Collections.Generic;



namespace PizzaBox.Client.ViewModel
{
    internal class PizzaView : BaseView
    {
        internal static void DisplayPizzas(List<Pizza> pizzas)
        {
            Console.WriteLine("-----------------------------------------");
            int menucount = 1;

            for (int i = 0; i <= pizzas.Count - 1; menucount++, i++)
            {
                Console.WriteLine($" ({menucount} )\t {pizzas[i].PType}");
            }
        }

        internal static void DisplayPizza(Pizza pizza)
        {
            Console.WriteLine($"{pizza.PType}"); 
        }

        internal static void DisplaySize(string[] pizzaSize)
        {
            int menucount = 1;

            for (int i = 0; i <= pizzaSize.Length - 1; menucount++, i++)
            {
                Console.WriteLine($" ({menucount} )\t {pizzaSize[i]}");
            }
        }

        internal static void DisplayCrust(string[] pizzaCrust)
        {
            int menucount = 1;

            for (int i = 0; i <= pizzaCrust.Length - 1; menucount++, i++)
            {
                Console.WriteLine($" ({menucount} )\t {pizzaCrust[i]}");
            }
        }

    }
}
