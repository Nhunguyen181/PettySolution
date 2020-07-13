using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Stores = new HashSet<Stores>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Stores> Stores { get; set; }
    }
}
