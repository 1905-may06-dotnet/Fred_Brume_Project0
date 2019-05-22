using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class PizzaToppings
    {
        public int PTopId { get; set; }
        public int TopId { get; set; }
        public int PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Toppings Top { get; set; }
    }
}
