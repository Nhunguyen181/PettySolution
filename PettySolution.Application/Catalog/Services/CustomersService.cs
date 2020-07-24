using PettySolution.Application.Catalog.Services;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog
{
    public class CustomersService: ServiceBase<Customers>, ICustomersService
    {
        private readonly projectContext _context;

        public CustomersService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
