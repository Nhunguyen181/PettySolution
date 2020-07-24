using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class ResponsesService : ServiceBase<Responses>,IResponsesService
    {
        private readonly projectContext _context;

        public ResponsesService(projectContext context):base(context)
        {
            _context = context;
        }
    }
}
