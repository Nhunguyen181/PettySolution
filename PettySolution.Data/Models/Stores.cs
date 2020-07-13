using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Stores
    {
        public Stores()
        {
            OrderProductStores = new HashSet<OrderProductStores>();
            Products = new HashSet<Products>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double? PositionX { get; set; }
        public double? PositionY { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Ward { get; set; }
        public string LogoImg { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<OrderProductStores> OrderProductStores { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
