using PettySolution.Application.Catalog.Services;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog
{
    public class HistoriesService : ServiceBase<Histories>, IHistoriesService
    {
        private readonly projectContext _context;

        public HistoriesService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
