using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Puser
    {
        public Puser()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
            Porder = new HashSet<Porder>();
        }

        public int PUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string PPassword { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }

        public virtual Plocation Location { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Porder> Porder { get; set; }
    }
}
