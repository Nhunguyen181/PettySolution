using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PettySolution.Application.Catalog;
using PettySolution.Data.Models;

namespace PettySolution.BackendAPI.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public ActionResult getCustomer(string username)
        {
            try
            {
                Customers customers = _customersService.Get(_ => _.Username == username);
                return Ok(customers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult create(string username, string password, string firstName, string lastName, DateTime dayOfBirth, string email, Boolean gender, Boolean active)
        {
            try
            {
                Customers customers = new Customers
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    DayOfBirth = dayOfBirth,
                    Email = email,
                    Gender = gender,
                    Active = active



                };
                _customersService.Add(customers);
                _customersService.SaveChanges();
                return Ok(customers.Username);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("Customers")]
        public ActionResult getAllCustomer()
        {
            try
            {
                List<Customers> customers = _customersService.GetAll().ToList();
                return Ok(customers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete")]
        public ActionResult Delete(string username)
        {
            try
            {
                _customersService.Delete(_ => _.Username == username);
                _customersService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult updateCustomer(string username, string password, string firstName, string lastName, DateTime dayOfBirth, Boolean gender, Boolean active)
        {
            try
            {
                Customers customers = _customersService.Get(_ => _.Username == username);
                if (customers == null) throw new Exception();
                customers.Username = username;
                customers.Password = password;
                customers.FirstName = firstName;
                customers.LastName = lastName;
                customers.DayOfBirth = dayOfBirth;
                customers.Gender = gender;
                customers.Active = active;

                _customersService.Update(customers);
                _customersService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}