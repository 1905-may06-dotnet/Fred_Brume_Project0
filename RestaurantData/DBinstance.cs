using PizzaBox.Data.Model;


namespace PizzaBox.Data
{
    public sealed class DBinstance
    {
     private static PizzaBoxDBContext pizzaBoxDBContext;

        private DBinstance()
        {

        }

        public static PizzaBoxDBContext Instance
        {
            get {

                if(pizzaBoxDBContext == null)
                {
                    pizzaBoxDBContext = new PizzaBoxDBContext();
                }

                return pizzaBoxDBContext;
            }
        }


    }
}
