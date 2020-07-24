using PettySolution.Application.Catalog.Services;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog
{
    public class AddressesService: ServiceBase<Addresses>, IAddressesService
    {
        private readonly projectContext _context;

        public AddressesService(projectContext context): base(context)
        {
            _context = context;
        }
    }
}
