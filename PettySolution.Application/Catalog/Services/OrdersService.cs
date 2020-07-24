using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class OrdersService : ServiceBase<Orders>,IOrdersService
    {
        private readonly projectContext _context;

        public OrdersService(projectContext context):base(context)
        {
            _context = context;
        }
    }
}
