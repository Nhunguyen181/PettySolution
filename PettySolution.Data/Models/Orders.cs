using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProductStores = new HashSet<OrderProductStores>();
        }

        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public string OrderStatus { get; set; }
        public double? Total { get; set; }
        public int? AddressId { get; set; }
        public string CustomerId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<OrderProductStores> OrderProductStores { get; set; }
    }
}
