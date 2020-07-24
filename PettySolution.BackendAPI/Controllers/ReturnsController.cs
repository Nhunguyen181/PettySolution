using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;

namespace PettySolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnsController : ControllerBase
    {
        private readonly IReturnsService _returnsService;

        public ReturnsController(IReturnsService returnsService)
        {
            _returnsService = returnsService;
        }
        [HttpGet]
        public ActionResult getReturn(int id)
        {
            try
            {
                 Returns returns = _returnsService.Get(_ => _.Id == id);
                return Ok(returns);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Returns")]
        public ActionResult getAll()
        {
            try
            {
                List<Returns> returns = _returnsService.GetAll().ToList();
                return Ok(returns);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(DateTime date, string reason, string confirms, int orderProductDetailID)
        {
            try
            {
                Returns returns = new Returns
                {
                    Date = date,
                    Reasion = reason,
                    Confirms = confirms,
                    OrderProductDetailId = orderProductDetailID





                };
                _returnsService.Add(returns);
                _returnsService.SaveChanges();
                return Ok(returns.Id);
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
                _returnsService.Delete(_ => _.Id == id);
                _returnsService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult update(int id, DateTime date, string reason, string confirms, int orderProductDetailID)
        {
            try
            {
                Returns returns = _returnsService.Get(_ => _.Id == id);
                if (returns == null) throw new Exception();
                returns.Date = date;
                returns.Reasion = reason;
                returns.Confirms = confirms;
                returns.OrderProductDetailId = orderProductDetailID;
                _returnsService.Update(returns);
                _returnsService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}