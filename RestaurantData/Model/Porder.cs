using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Porder
    {
        public int OrderId { get; set; }
        public string PDate { get; set; }
        public string PTime { get; set; }
        public string OrderCost { get; set; }
        public int PizzaId { get; set; }
        public int PUserId { get; set; }
        public int CLocationId { get; set; }

        public virtual Plocation CLocation { get; set; }
        public virtual Puser PUser { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
