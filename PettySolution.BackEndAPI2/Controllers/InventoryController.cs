using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PettySolution.BackEndAPI2.Models;
using PettySolution.BackEndAPI2.Services;

namespace PettySolution.BackEndAPI2.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _services;
        public InventoryController(IInventoryService services)
        {
            _services = services;
        }


        [HttpPost]
        public ActionResult<InventoryItem> AddInventoryItems(InventoryItem item)
        {
            var inven = _services.AddInventoryItem(item);
                if (inven == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}