using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Toppings
    {
        public Toppings()
        {
            PizzaToppings = new HashSet<PizzaToppings>();
        }

        public int TopId { get; set; }
        public string TName { get; set; }
        public string Cost { get; set; }
        public string T_Type { get; set; }
        public int PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<PizzaToppings> PizzaToppings { get; set; }
    }
}
