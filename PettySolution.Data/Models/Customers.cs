using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Addresses = new HashSet<Addresses>();
            Histories = new HashSet<Histories>();
            Orders = new HashSet<Orders>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Histories> Histories { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
