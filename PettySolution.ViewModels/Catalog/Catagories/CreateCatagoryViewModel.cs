using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.ViewModels.Catalog.Catagories
{
    public class CreateCatagoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
