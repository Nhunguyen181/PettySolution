using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class OrderProductDetailsService : ServiceBase<OrderProductDetails>, IOrderProductDetailsService
    {
        private readonly projectContext _context;

        public OrderProductDetailsService(projectContext context):base(context)
        {
            _context = context;
        }
    }
}
