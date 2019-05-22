using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Plocation
    {
        public Plocation()
        {
            Pizza = new HashSet<Pizza>();
            Porder = new HashSet<Porder>();
            Puser = new HashSet<Puser>();
        }

        public int LocationId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PState { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
        public virtual ICollection<Porder> Porder { get; set; }
        public virtual ICollection<Puser> Puser { get; set; }
    }
}
