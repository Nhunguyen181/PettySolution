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
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storesService;

        public StoresController(IStoresService storesService)
        {
            _storesService = storesService;
        }
        [HttpGet]
        public ActionResult getStore(string username)
        {
            try
            {
                Stores history = _storesService.Get(_ => _.Username.Equals(username));
                return Ok(history);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("login")]
        public ActionResult login(string username, string password)
        {
            try
            {
                Stores stores = _storesService.Get(_ => _.Username == username && _.Password == password);
                return Ok(stores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Stores")]
        public ActionResult getAll()
        {
            try
            {
                List<Stores> stores = _storesService.GetAll().ToList();
                return Ok(stores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(string username, string password, string name, DateTime date, bool active, string description,
            string detail, string district, string email, string phone, double posX, double posY, string postalCode, string province, string ward,
            string logoImg, int roleID)
        {
            try
            {
                Stores stores = new Stores
                {
                    Username = username,
                    Password = password,
                    Name = name,
                    Date = date,
                    Active = active,
                    Description = description,
                    Detail = detail,
                    District = district,
                    Email = email,
                    Phone = phone,
                    PositionX = posX,
                    PositionY = posY,
                    PostalCode = postalCode,
                    Province = province,
                    Ward = ward,
                    LogoImg = logoImg,
                    RoleId = roleID,




                };
                _storesService.Add(stores);
                _storesService.SaveChanges();
                return Ok(stores.Username);
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

                _storesService.Delete(_ => _.Username == username);
                _storesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult update(string username, string password, string name, DateTime date, bool active, string description,
            string detail, string district, string email, string phone, double posX, double posY, string postalCode, string province, string ward,
            string logoImg, int roleID)
        {
            try
            {
                Stores stores = _storesService.Get(_ => _.Username == username);
                if (stores == null) throw new Exception();

                stores.Username = username;
                stores.Password = password;
                stores.Name = name;
                stores.Date = date;
                stores.Active = active;
                stores.Description = description;
                stores.Detail = detail;
                stores.District = district;
                stores.Email = email;
                stores.Phone = phone;
                stores.PositionX = posX;
                stores.PositionY = posY;
                stores.Username = username;
                stores.PostalCode = postalCode;

                stores.Province = province;

                stores.Ward = ward;
                stores.LogoImg = logoImg;
                stores.RoleId = roleID;






                _storesService.Update(stores);
                _storesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}