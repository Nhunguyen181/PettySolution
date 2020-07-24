using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class OrderProductStoresService : ServiceBase<OrderProductStores>,IOrderProductStoresService
    {
        private readonly projectContext _context;

        public OrderProductStoresService(projectContext context):base(context)
        {
            _context = context;
        }
    }
}
