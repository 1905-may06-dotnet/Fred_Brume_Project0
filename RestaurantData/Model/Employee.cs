using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Employee
    {
        public int EUserId { get; set; }
        public int PUserId { get; set; }
        public string Position { get; set; }

        public virtual Puser PUser { get; set; }
    }
}
