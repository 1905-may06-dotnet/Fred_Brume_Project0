using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaToppings = new HashSet<PizzaToppings>();
            Porder = new HashSet<Porder>();
            Toppings = new HashSet<Toppings>();
        }

        public int PizzaId { get; set; }
        public string PType { get; set; }
        public string PPrice { get; set; }
        public string PSize { get; set; }
        public string Crust { get; set; }
        public int SLocationId { get; set; }

        public virtual Plocation SLocation { get; set; }
        public virtual ICollection<PizzaToppings> PizzaToppings { get; set; }
        public virtual ICollection<Porder> Porder { get; set; }
        public virtual ICollection<Toppings> Toppings { get; set; }
    }
}
