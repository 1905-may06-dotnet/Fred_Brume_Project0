
using System;

namespace PizzaBox.Client.ViewModel
{
    class Program : AuthenticationView
    {
        public static void init()
        {

            Program program = new Program();
            program.AuthenticateUser();
        }

        static void Main(string[] args)
        {
            init();
        }
    }
}
