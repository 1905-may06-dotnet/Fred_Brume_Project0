using PizzaBox.Data.Model;
using PizzaBox.Domain.Handler;
using System;


namespace PizzaBox.Client.ViewModel
{
    public class AuthenticationView : BaseView
    {
        enum authOptions
        {
            signIn,
            signUp,
        }

        public void AuthenticateUser()
        {
            int option = 0;

            Console.WriteLine();
            Console.WriteLine(" Enter (1) to Sign in or (2) to Sign Up if you dont an account with us:");

            do
            {
                Console.WriteLine();
                option = base.GetValidatedOption(2);

            } while (option == -1);

            switch (option - 1)
            {
                case (int)authOptions.signIn:
                    {
                        bool validateLogin = false;
                        Puser user = null;

                        do
                        {
                            Console.WriteLine();
                            validateLogin = SignInUser(ref user);

                        } while (!validateLogin);

                        MainView.DisplayUserDetails(user);
                        break;
                    }
                   

                case (int) authOptions.signUp:
                    {
                        SignUpView signUp = new SignUpView();
                        signUp.SignUpUser();
                        break;
                    }
            }


        }

        private bool SignInUser(ref Puser user1)
        {
            string username = base.GetInput(" Type in your username: ");
            Console.WriteLine();

            string password = base.GetInput(" Type in your password: ");
            Console.WriteLine();

            Puser user = UserHandler.ValidateUser(username, password);

            user1 = user;

            return (user != null)? true : false;
        }

    }
}
