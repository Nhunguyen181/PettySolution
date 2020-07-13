using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Detail { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CustomerId { get; set; }
        public string StoreId { get; set; }
        public string Province { get; set; }
        public string Ward { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
