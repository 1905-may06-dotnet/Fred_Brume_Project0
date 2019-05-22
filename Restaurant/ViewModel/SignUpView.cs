using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using System;


namespace PizzaBox.Client.ViewModel
{
    public class SignUpView : AuthenticationView
    {
        internal void SignUpUser()
        {
            bool validate;
            string firstName, lastName, username, password, email, street, city, state, zipcode;
            do
            {
                firstName = base.GetInput(" Type in your First Name: ");
                Console.WriteLine();

                lastName = base.GetInput(" Type in your Last Name: ");
                Console.WriteLine();

                username = base.GetInput(" Type in your username: ");
                Console.WriteLine();

                password = base.GetInput(" Type in your password: ");
                Console.WriteLine();

                email = base.GetInput(" Type in your email: ");
                Console.WriteLine();

                street = base.GetInput(" Type in your street: ");
                Console.WriteLine();

                city = base.GetInput(" Type in your city: ");
                Console.WriteLine();

                state = base.GetInput(" Type in your state: ");
                Console.WriteLine();

                zipcode = base.GetInput(" Type in your zipcode: ");
                Console.WriteLine();

                validate = validateFields(firstName, lastName, username, password, email, street, city, state, zipcode);

            } while (validate == false);

            bool checkInsert = UserHandler.InsertUser(firstName, lastName, username, password, email, street, city, state, zipcode);


            if(checkInsert != true)
            {
                Console.WriteLine("There was somthing wrong with your insertion: ");
                Console.WriteLine("Pls try inserting your inputs again: ");

                SignUpUser();
            }else
            {
                Console.WriteLine("User Insertion successful: ");
            }
        }

        private static bool validateFields(string firstName, string lastName, 
            string username, string password, string email, string street, string city, string state, string zipcode)
        {
            bool validate = true;
          
                if (firstName.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your FIRSTNAME");
                    validate = false;
                }
                if (lastName.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your LASTNAME");
                    validate = false;
                }
                if (username.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your USERNAME");
                    validate = false;
                }
                if (password.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your PASSWORD");
                    validate = false;
                }
                if (email.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your EMAIL");
                    validate = false;
                }
                if (street.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your STREET");
                    validate = false;
                }
                if (city.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your CITY");
                    validate = false;
                }
                if (state.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your STATE");
                    validate = false;
                }
                if (zipcode.Trim().Equals(""))
                {
                    Console.WriteLine("You didnt type in your ZIPCODE");
                    validate = false;
                }

                if(validate == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Some INPUTS are missing or NOT VALID: ");
                }
          

            return validate;

        }
    }
}
