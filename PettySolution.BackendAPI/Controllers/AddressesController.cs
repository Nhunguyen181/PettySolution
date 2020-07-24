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
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService _addressesService;

        public AddressesController(IAddressesService addressesService)
        {
            _addressesService = addressesService;
        }
        [HttpGet]
        public ActionResult getAddress(int id)
        {
            try
            {
                Addresses address = _addressesService.Get(_ => _.Id == id);
                return Ok(address);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Adressess")]
        public ActionResult getAllUserAddress()
        {
            try
            {
                List<Addresses> addresses = _addressesService.GetAll().ToList();
                return Ok(addresses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Customer")]
        public ActionResult getCustomerAddress(string id)
        {
            try
            {
                List<Addresses> addresses = _addressesService.GetMany(_ => _.CustomerId == id).ToList();
                return Ok(addresses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(String name, String detail, String phone, String customerID, String storeID, String province, String ward)
        {
            try
            {
                Addresses addresses = new Addresses
                {
                    Name = name,
                    Detail = detail,
                    Phone = phone,
                    CustomerId = customerID,
                    StoreId = storeID,
                    Province = province,
                    Ward = ward

                };
                _addressesService.Add(addresses);
                _addressesService.SaveChanges();
                return Ok(addresses.Id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                _addressesService.Delete(_ => _.CustomerId == id);
                _addressesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult updateName(string id, string district, string province, string ward, string detail, string name, string phone)
        {
            try
            {
                Addresses addresses = _addressesService.Get(_ => _.CustomerId == id);
                if (addresses == null) throw new Exception();
                addresses.District = district;
                addresses.Province = province;
                addresses.Ward = ward;
                addresses.Detail = detail;
                addresses.Name = name;
                addresses.Phone = phone;

                _addressesService.Update(addresses);
                _addressesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}