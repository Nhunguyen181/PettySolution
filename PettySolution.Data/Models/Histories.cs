using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Histories
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string CustomerId { get; set; }
        public int? ProductId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Products Product { get; set; }
    }
}
