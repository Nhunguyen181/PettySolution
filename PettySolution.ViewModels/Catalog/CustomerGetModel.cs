using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.ViewModels.Catalog
{
    public  class CustomerGetModel
    {
    }
    public class CustomerGetViewModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public bool Active { get; set; }
    }
}
