using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PettySolution.Application.Catalog;
using PettySolution.Data.Models;

namespace PettySolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly IHistoriesService _historiesService;

        public HistoriesController(IHistoriesService historiesService)
        {
            _historiesService = historiesService;
        }
        [HttpGet]
        public ActionResult getHistory(int id)
        {
            try
            {
                Histories history = _historiesService.Get(_ => _.Id == id);
                return Ok(history);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(DateTime date, string customerID, int productID)
        {
            try
            {
                Histories histories = new Histories
                {
                    Date = date,
                    CustomerId = customerID,
                    ProductId = productID
                };
                _historiesService.Add(histories);
                _historiesService.SaveChanges();
                return Ok(histories.Id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("Histories")]
        public ActionResult getAll()
        {
            try
            {
                List<Histories> histories = _historiesService.GetAll().ToList();
                return Ok(histories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _historiesService.Delete(_ => _.Id == id);
                _historiesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult updateCustomer(int id, DateTime date, string customerID, int productID)
        {
            try
            {
                Histories histories = _historiesService.Get(_ => _.Id == id);
                if (histories == null) throw new Exception();
                histories.Date = date;
                histories.CustomerId = customerID;
                histories.ProductId = productID;



                _historiesService.Update(histories);
                _historiesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}