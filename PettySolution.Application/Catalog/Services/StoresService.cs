using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class StoresService : ServiceBase<Stores>, IStoresService
    {
        private readonly projectContext _context;

        public StoresService(projectContext context):base(context)
        {
            _context = context;
        }
    }
}
