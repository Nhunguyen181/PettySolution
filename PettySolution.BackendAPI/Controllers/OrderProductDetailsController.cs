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
    public class OrderProductDetailsController : ControllerBase
    {
        IOrderProductDetailsService _orderProductDetailsService;

        public OrderProductDetailsController(IOrderProductDetailsService orderProductDetailsService)
        {
            _orderProductDetailsService = orderProductDetailsService;
        }
        [HttpGet]
        public ActionResult getOrderProductDetail(int id)
        {
            try
            {
                OrderProductDetails orderProductDetails = _orderProductDetailsService.Get(_ => _.Id == id);
                return Ok(orderProductDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("OrderProductDetails")]
        public ActionResult getAll()
        {
            try
            {
                List<OrderProductDetails> orderProductDetails = _orderProductDetailsService.GetAll().ToList();
                return Ok(orderProductDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(DateTime date, int quantity, int price, string orderStatus, int orderProductStoreID, int productID)
        {
            try
            {
                OrderProductDetails orderProductDetails = new OrderProductDetails
                {
                    Date = date,
                    Quantity = quantity,
                    Price = price,
                    OrderStatus = orderStatus,
                    OrderProductStoreId = orderProductStoreID,
                    ProductId = productID



                };
                _orderProductDetailsService.Add(orderProductDetails);
                _orderProductDetailsService.SaveChanges();
                return Ok(orderProductDetails.Id);
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
                _orderProductDetailsService.Delete(_ => _.Id == id);
                _orderProductDetailsService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult update(int id, DateTime date, int quantity, int price, string orderStatus, int orderProductStoreID, int productID)
        {
            try
            {
                OrderProductDetails orderProductDetails = _orderProductDetailsService.Get(_ => _.Id == id);
                if (orderProductDetails == null) throw new Exception();

                orderProductDetails.Date = date;
                orderProductDetails.Quantity = quantity;
                orderProductDetails.Price = price;
                orderProductDetails.OrderStatus = orderStatus;
                orderProductDetails.OrderProductStoreId = orderProductStoreID;
                orderProductDetails.ProductId = productID;

                _orderProductDetailsService.Update(orderProductDetails);
                _orderProductDetailsService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}