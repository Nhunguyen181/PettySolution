using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.ViewModels.Catalog
{
    public class OrderProductStoresViewModel
    {
    }
    public class OrderProductStoreGetModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Note { get; set; }
        public string OrderStatus { get; set; }
        public double? Total { get; set; }

        public Orders Order { get; set; }
        public Addresses Address { get; set; }
        public Customers Customers { get; set; }
        public List<OrderProductDetails> OrderProductDetails { get; set; }
    }
}
