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
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult getProduct(int id)
        {
            try
            {
                Products products = _productsService.Get(_ => _.Id == id);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Store")]
        public ActionResult getProduct(string storeId)
        {
            try
            {
                List<Products> products = _productsService.GetMany(_ => _.StoreId == storeId).ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Products")]
        public ActionResult getAll()
        {
            try
            {
                List<Products> products = _productsService.GetAll().ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(int id, string brand, string name, string description, DateTime expiration, string img,
            string price, string netWeight, string origin, int categoryId, int quantity, string storeId, DateTime startDate, string size, Boolean status)
        {
            try
            {
                Products products = new Products
                {
                    Brand = brand,
                    Name = name,
                    Description = description,
                    Expiration = expiration,
                    Img = img,
                    Price = price,
                    NetWeight = netWeight,
                    Origin = origin,
                    CategoryId = categoryId,
                    Quantity = quantity,
                    StoreId = storeId,
                    StartDate = startDate,
                    Size = size,
                    Status = status







                };
                _productsService.Add(products);
                _productsService.SaveChanges();
                return Ok(products.Id);
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

                _productsService.Delete(_ => _.Id == id);
                _productsService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult update(int id, string brand, string name, string description, DateTime expiration, string img,
            string price, string netWeight, string origin, int categoryId, int quantity, string storeId, DateTime startDate, string size, Boolean status)
        {
            try
            {
                Products products = _productsService.Get(_ => _.Id == id);
                if (products == null) throw new Exception();
                products.Brand = brand;
                products.Name = name;
                products.Description = description;
                products.Expiration = expiration;
                products.Img = img;
                products.Price = price;
                products.NetWeight = netWeight;
                products.Origin = origin;
                products.CategoryId = categoryId;
                products.Quantity = quantity;
                products.StoreId = storeId;
                products.StartDate = startDate;
                products.Status = status;
                products.Size = size;


                _productsService.Update(products);
                _productsService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Search")]
        public ActionResult getByNameStore(string name, string store)
        {
            try
            {
                List<Products> products = _productsService.GetMany(_ => _.Name.Trim().ToLower().Contains(name.Trim().ToLower()) && _.StoreId.Equals(store)).ToList();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}