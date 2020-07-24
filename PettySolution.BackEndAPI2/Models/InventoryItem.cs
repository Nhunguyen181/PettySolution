using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PettySolution.BackEndAPI2.Models
{
    public class InventoryItem
    {
        public int Id { get;set }
        public string ItemName { get;set }

        public double Price { get;set }
    }
}
