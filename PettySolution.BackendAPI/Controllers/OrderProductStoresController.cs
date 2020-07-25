using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PettySolution.Application.Catalog;
using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using PettySolution.ViewModels.Catalog;

namespace PettySolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductStoresController : ControllerBase
    {
        private readonly IOrderProductStoresService _orderProductStoresService;
        private readonly IOrderProductDetailsService _orderProductDetailsService;
        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;
        private readonly IAddressesService _addressesService;
        private readonly ICustomersService _customersService;

        public OrderProductStoresController(IOrderProductStoresService orderProductStoresService, IOrderProductDetailsService orderProductDetailsService, IProductsService productsService, IOrdersService ordersService, IAddressesService addressesService, ICustomersService customersService)
        {
            _orderProductStoresService = orderProductStoresService;
            _orderProductDetailsService = orderProductDetailsService;
            _productsService = productsService;
            _ordersService = ordersService;
            _addressesService = addressesService;
            _customersService = customersService;
        }
        [HttpGet("{id}")]
        public ActionResult getOrderProductStore(int id)
        {
            try
            {
                OrderProductStores orderProductStores = _orderProductStoresService.Get(_ => _.Id == id);
                List<OrderProductDetails> orderProductDetails = _orderProductDetailsService.GetMany(_ => _.OrderProductStoreId == orderProductStores.Id).ToList();
                orderProductDetails.ForEach(_ =>
                {
                    Products product = _productsService.Get(__ => __.Id == _.ProductId);
                    _.Product = product;
                });
                Orders order = _ordersService.Get(_ => _.Id == orderProductStores.OrderId);
                Addresses address = _addressesService.Get(_ => _.Id == order.AddressId);
                OrderProductStoreGetModel orderProductStoreGetModel = new OrderProductStoreGetModel
                {
                    Id = orderProductStores.Id,
                    Date = orderProductStores.Date,
                    Note = orderProductStores.Note,
                    /*  Order = order,*/

                    Address = address,

                    OrderProductDetails = orderProductDetails,
                    /* OrderStatus = orderProductStores.OrderStatus,
                     Total = orderProductStores.Total*/
                };
                return Ok(orderProductStoreGetModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("OrderProductStores")]
        public ActionResult getAll()
        {
            try
            {
                List<OrderProductStores> orderProductStores = _orderProductStoresService.GetAll().ToList();
                return Ok(orderProductStores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(DateTime date, string note, string orderId, string orderStatus, string storeID, int total)
        {
            try
            {
                OrderProductStores orderProductStores = new OrderProductStores
                {
                    Date = date,
                    Note = note,
                    OrderId = orderId,
                    OrderStatus = orderStatus,
                    StoreId = storeID,
                    Total = total



                };
                _orderProductStoresService.Add(orderProductStores);
                _orderProductStoresService.SaveChanges();
                return Ok(orderProductStores.Id);
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
                _orderProductStoresService.Delete(_ => _.Id == id);
                _orderProductStoresService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult update(int id, DateTime date, string note, string orderId, string orderStatus, string storeID, int total)
        {
            try
            {
                OrderProductStores orderProductStores = _orderProductStoresService.Get(_ => _.Id == id);
                if (orderProductStores == null) throw new Exception();

                orderProductStores.Date = date;
                orderProductStores.Note = note;
                orderProductStores.OrderId = orderId;
                orderProductStores.OrderStatus = orderStatus;
                orderProductStores.StoreId = storeID;
                orderProductStores.Total = total;

                _orderProductStoresService.Update(orderProductStores);
                _orderProductStoresService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Store/{storeID}")]
        public ActionResult getByStore(string storeID)
        {
            try
            {
                List<OrderProductStores> orderProductStores = _orderProductStoresService.GetMany(_ => _.StoreId == storeID).ToList();
                return Ok(orderProductStores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}