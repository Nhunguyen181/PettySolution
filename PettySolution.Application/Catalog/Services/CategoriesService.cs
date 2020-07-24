using PettySolution.Application.Catalog.Services;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog
{
 
    public class CategoriesService: ServiceBase<Categories>, ICategoriesService
    {
        private readonly projectContext _context;

        public CategoriesService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
