using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Products
    {
        public Products()
        {
            Histories = new HashSet<Histories>();
            OrderProductDetails = new HashSet<OrderProductDetails>();
            Responses = new HashSet<Responses>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration { get; set; }
        public string Img { get; set; }
        public string Price { get; set; }
        public string NetWeight { get; set; }
        public string Origin { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public string StoreId { get; set; }
        public DateTime? StartDate { get; set; }
        public string Size { get; set; }
        public bool? Status { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<Histories> Histories { get; set; }
        public virtual ICollection<OrderProductDetails> OrderProductDetails { get; set; }
        public virtual ICollection<Responses> Responses { get; set; }
    }
}
