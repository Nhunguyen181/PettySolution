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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public ActionResult getOrder(string id)
        {
            try
            {
                Orders orders = _ordersService.Get(_ => _.Id.Equals(id));
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Orders")]
        public ActionResult getAll()
        {
            try
            {
                List<Orders> orders = _ordersService.GetAll().ToList();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(string id, DateTime date, string orderstatus, int total, int addressID, string customerID)
        {
            try
            {
                Orders orders = new Orders
                {
                    Date = date,
                    AddressId = addressID,
                    CustomerId = customerID,
                    OrderStatus = orderstatus,
                    Total = total



                };
                _ordersService.Add(orders);
                _ordersService.SaveChanges();
                return Ok(orders.Id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete")]
        public ActionResult Delete(string id)
        {
            try
            {

                _ordersService.Delete(_ => _.Id == id);
                _ordersService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult update(string id, DateTime date, string orderstatus, int total, int addressID, string customerID)
        {
            try
            {
                Orders orders = _ordersService.Get(_ => _.Id == id);
                if (orders == null) throw new Exception();

                orders.Date = date;
                orders.OrderStatus = orderstatus;
                orders.AddressId = addressID;
                orders.Total = total;
                orders.CustomerId = customerID;

                _ordersService.Update(orders);
                _ordersService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}