using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class ProductsService : ServiceBase<Products>,IProductsService
    {
        private readonly projectContext _context;

        public ProductsService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
