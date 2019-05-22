using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using PizzaBox.Domain.Model;
using RestaurantLogic;
using System;
using System.Collections.Generic;


namespace PizzaBox.Client.ViewModel
{
    public class CustomerView : BaseView, IUserView
    {

       private int index;
       private Puser user;
       private int listCount = 1;
       private int option;
       private double currentCost = 0;
       private List<Plocation> locations;
       private Plocation location;
       private List<Pizza> pizzas;
       private List<Porder> orders;
       private List<Toppings> chosenToppings;
       private int numPizza;
       private int maxPizza = 0;
       private double totalCost = 0;

        private void CustomerLocation()
        {

           locations = LocationHandler.GetLocationData();

            Console.WriteLine("Choose from the Store Locations below: ");
            LocationView.DisplayLocationsOptions(locations);

            do
            {
                Console.WriteLine();
                index = base.GetValidatedOption(locations.Count - 1);

            } while (index == -1);

            location = locations[index];
            LocationView.DisplayLocation(locations, index);

            Console.WriteLine();
            Console.WriteLine();
        }

        private void MainOptions()
        {
            Console.WriteLine("===================== CUSTOMER ==================");
            Console.WriteLine();
            Console.WriteLine($"Choose from the options below from 1 to {menuCustomer.Length}");
            Console.WriteLine();


            for (int i = 0; i < menuCustomer.Length; listCount++, i++)
            {
                Console.WriteLine($" ({listCount}) \t {menuCustomer[i]}");
            }

            Console.WriteLine();

            do
            {
                option = base.GetValidatedOption(menuCustomer.Length);

            } while (option == -1);
        }

        private void CustomerPizzas()
        {
            //Check for pizza Count
            bool pizzaCountValid;

            do
            {
                numPizza = base.ValidateIntegerOption(base.GetInput("How many pizzas would you like to buy ? "));
                pizzaCountValid = PizzaHandler.validatePizzaCount(ref maxPizza, numPizza);

                if (pizzaCountValid == false)
                {
                    Console.WriteLine("You can't Order more than 100 pizzas");
                }
            } while (numPizza > maxPizza);

            pizzas = PizzaHandler.GetPizzasFromLocation(locations[index - 1]);
            

        }

        private void CustomerToppings()
        {

        }

        private void CustomerSelectedPizza()
        {

        }

        public void CustomerOrder()
        {
            orders = new List<Porder>();

            //Iterate base on pizza count
            for (int i = 1; i <= numPizza; i++)
            {
                if (OrderHandler.validateCurrentCost(currentCost))
                {
                    Console.WriteLine("Choose from the List of Pizzas: ");
                    PizzaView.DisplayPizzas(pizzas);

                    do  //this code is a repetitive code. create a method for it
                    {
                        Console.WriteLine();
                        index = base.GetValidatedOption(pizzas.Count);

                    } while (index == -1);

                    Console.WriteLine();

                    //Get the pizza from the list
                    Pizza pizza = pizzas[index - 1];

                    Console.WriteLine("You chose this Pizza from the menu");
                    PizzaView.DisplayPizza(pizza);
                    Console.WriteLine();


                    Console.WriteLine("Choose from the List of Pizza sizes below");
                    Console.WriteLine();

                    string[] pizzaSizes = PizzaHandler.pizzaSize;
                    PizzaView.DisplaySize(pizzaSizes);

                    do
                    {
                        Console.WriteLine();
                        index = base.GetValidatedOption(pizzaSizes.Length);

                    } while (index == -1);

                    string pizzaSize = pizzaSizes[index - 1];  //Size of the pizza

                    Console.WriteLine();
                    Console.WriteLine($"You chose [{pizzaSizes[index - 1]}] from the list of sizes");
                    Console.WriteLine();


                    Console.WriteLine("Choose from the List of Pizza Crust below");
                    Console.WriteLine();
                    string[] pizzaCrusts = PizzaHandler.pizzaCrust;
                    PizzaView.DisplayCrust(pizzaCrusts);

                    do
                    {
                        Console.WriteLine();
                        index = base.GetValidatedOption(pizzaCrusts.Length);

                    } while (index == -1);


                    string pizzaCrust = pizzaCrusts[index - 1];

                    Console.WriteLine();
                    Console.WriteLine($"You chose [{pizzaCrust[index - 1]}] from the list of Crust");
                    Console.WriteLine();


                    chosenToppings = new List<Toppings>();

                    Console.WriteLine("Choose from the Toppings on the List:");
                    List<Toppings> toppings = ToppingsHandler.GetToppings(pizza);
                    List<Toppings> defaultToppings = ToppingsHandler.GetDefaultToppings(pizza);

                    ToppingView.DisplayToppings(toppings);
                    ToppingView.DisplayDefaultToppings(toppings);


                    //Check for Toppings Count
                    int numToppings, maxToppings = 0;
                    bool toppingCountValid;
                    do
                    {
                        numToppings = base.ValidateIntegerOption(base.GetInput("How many Toppings would you like on yout Pizza ? "));
                        toppingCountValid = ToppingsHandler.validateToppingsCount(ref maxToppings, numToppings);

                        if (toppingCountValid == false)
                        {
                            Console.WriteLine("You can't have more than Five(5) toppings on your pizza");
                        }

                    } while (numPizza > maxPizza);


                    for (int t = 1; t <= numToppings; t++)
                    {
                        do
                        {
                            index = base.GetValidatedOption(toppings.Count);

                        } while (index == -1);

                        chosenToppings.Add(toppings[index]);
                    }

                    //Re assign chosen topping when the default toppings has been added
                    chosenToppings = ToppingsHandler.AddDefaultToChosenToppings(chosenToppings, defaultToppings);

                    //Add Default to Chosen

                    ToppingView.DisplayToppings(chosenToppings);
                    double toppingsCost = ToppingsHandler.TotalToppingsCost(chosenToppings);
                    ToppingView.DisplayToppingsTotalCost(toppingsCost);

                    Pizza pizzaOrder = PizzaHandler.GetPizzaPrice(pizza.PType, pizzaSize, pizzaCrust);

                    currentCost = OrderHandler.GetOrderCost(Convert.ToDouble(pizzaOrder.PPrice), toppingsCost);
                    OrderView.DisplayOrderCost(currentCost);

                    totalCost += currentCost;


                    orders.Add(new Porder
                    {
                        PDate = DateTime.Now.ToString("M/d/yyyy"),
                        PTime = DateTime.Now.ToShortTimeString(),
                        OrderCost = Convert.ToString(currentCost),
                        PizzaId = pizzaOrder.PizzaId,
                        PUserId = user.PUserId,
                        CLocationId = location.LocationId

                    });

                }
                else
                {
                    Console.WriteLine("You cant order more than 5000 pizza cost");
                    displayView(user);
                }
            }

            OrderView.DisplayTotalOrderCost(totalCost);
            Console.WriteLine();

            string orderOption;

            do
            {
                orderOption = base.GetInput("Are you sure about your Order ?. Type in YES to accept or NO to decline ");

                if (orderOption.ToLower().Equals("yes"))
                {
                    bool inserted = OrderHandler.InsertOrders(orders);

                    if(inserted == true)
                    {
                        Console.WriteLine(" Yay!  Your Order has been placed  ");
                        Console.WriteLine("Thank you for choosing PizaBox");
                    }

                }else if (orderOption.ToLower().Equals("no"))
                {
                    Console.WriteLine("Thank you for choosing PizaBox");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Incorrect Option, pls try again.");
                    Console.WriteLine();
                }

            } while (orderOption.ToLower().Equals("yes") || orderOption.ToLower().Equals("no"));

   
        }

        public void displayView(Puser user)
        {
            this.user = user;

            MainOptions();
           

            switch (option - 1)
            {
                case (int)menuCustomerConst.Order:
                    {
                        CustomerLocation();

                        bool validateDate = OrderHandler.CheckOrderDateTime(location, user);

                        if (validateDate == true)
                        {
                            CustomerPizzas();
                            CustomerOrder();
                        }
                        else
                        {
                            Console.WriteLine("Can't Order From another Location within 24 hours");
                            Console.WriteLine("Pls Choose another location:");

                            displayView(user);
                            listCount = 1;
                        }
                
                        break;
                    }

                case (int)menuCustomerConst.View:
                    {
                        List<Porder> orders = OrderHandler.GetOrders();
                        OrderView.DisplayOrders(orders);

                        break;
                    }

            }


        }
    }
}
