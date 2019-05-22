
using System;

namespace PizzaBox.Client.ViewModel
{
    public abstract class BaseView
    {

        internal enum menuAdminConst
        {
            Stores,
            Pizzas,
            Order,
            Customer,
            Sales,
            Users
        }

        internal enum menuCustomerConst
        {
            Order,
            View,
        }

        internal static string[] menuAdmin = { "View Stores", "View Pizzas", "View Order", "View Customer", "View Sales" };
        internal static string[] menuCustomer = {"Order Pizza", "View Order"};



        public virtual string GetInput(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }

        public virtual int ValidateIntegerOption(string input)
        {
            int option = 0;
            try
            {
                option = Convert.ToInt32(input);
            }
            catch(FormatException f)
            {
                Console.Write("The Option Format is incorrect, pls try typing a valid option");
                return -1;
               
            }
            catch(OverflowException o){

                Console.Write("The Option Format is incorrect, pls try typing a valid option");
                return -1;
            }
            catch(Exception e)
            {
                Console.Write("The Option Format is incorrect, pls try typing a valid option");
                return -1;
            }

            return option;
            
        }
        public virtual bool ValidateOptionRange(int option, int length)
        {
            if(option > 0 && option <= length)
            {
                return true;
            }else
            {
                Console.WriteLine($"The number is not between 1 and {length}, pls try a different option ");
                return false;
            }
        }

        public virtual int GetValidatedOption(int length)
        {
            string menuOption;
            int validatedOption;

            Console.WriteLine();
            menuOption = GetInput("Pls Type in your option: ");
            Console.WriteLine();

            validatedOption = ValidateIntegerOption(menuOption);  //check if the option is an int value

            if (validatedOption != -1)
            {
                if (!ValidateOptionRange(validatedOption, length)) validatedOption = -1;  //check the range is valid
            }

            return validatedOption;
        }

    }
}
