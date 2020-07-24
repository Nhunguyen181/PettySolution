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
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        [HttpGet]
        public ActionResult getRole(int id)
        {
            try
            {
                Roles roles = _rolesService.Get(_ => _.Id == id);
                return Ok(roles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("roles")]
        public ActionResult getRoles()
        {
            try
            {
                List<Roles> roles = _rolesService.GetAll().ToList();
                return Ok(roles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(String name)
        {
            try
            {
                Roles roles = new Roles
                {
                    Name = name
                };
                _rolesService.Add(roles);
                _rolesService.SaveChanges();
                return Ok(roles.Id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult updateName(int id, string name)
        {
            try
            {
                Roles roles = _rolesService.Get(_ => _.Id == id);
                roles.Name = name;
                _rolesService.Update(roles);
                _rolesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _rolesService.Delete(_ => _.Id == id);
                _rolesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}