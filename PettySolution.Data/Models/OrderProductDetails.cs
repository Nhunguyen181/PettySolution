using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class OrderProductDetails
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string OrderStatus { get; set; }
        public int? OrderProductStoreId { get; set; }
        public int? ProductId { get; set; }

        public virtual OrderProductStores OrderProductStore { get; set; }
        public virtual Products Product { get; set; }
        public virtual Responses Responses { get; set; }
        public virtual Returns Returns { get; set; }
    }
}
