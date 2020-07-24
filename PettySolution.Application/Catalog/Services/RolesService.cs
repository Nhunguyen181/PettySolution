using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class RolesService : ServiceBase<Roles>, IRolesService
    {
        private readonly projectContext _context;

        public RolesService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
