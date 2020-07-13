using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
