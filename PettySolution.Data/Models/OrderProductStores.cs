using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class OrderProductStores
    {
        public OrderProductStores()
        {
            OrderProductDetails = new HashSet<OrderProductDetails>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Note { get; set; }
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string StoreId { get; set; }
        public double? Total { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<OrderProductDetails> OrderProductDetails { get; set; }
    }
}
