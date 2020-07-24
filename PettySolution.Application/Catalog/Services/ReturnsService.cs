using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class ReturnsService : ServiceBase<Returns>, IReturnsService
    {
        private readonly projectContext _context;

        public ReturnsService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
