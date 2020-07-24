using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PettySolution.Application.Catalog;
using PettySolution.Data.Models;

namespace PettySolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [Authorize]
        [HttpGet]
        public ActionResult getCategory(int id)
        {
            try
            {
                Categories category = _categoriesService.Get(_ => _.Id == id);
                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Categories")]
        public ActionResult getAllCategories()
        {
            try
            {
                List<Categories> categories = _categoriesService.GetAll().ToList();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult create(String id, String name, String description, String img)
        {
            try
            {
                Categories categories = new Categories
                {
                    Name = name,
                    Description = description,
                    Img = img,


                };
                _categoriesService.Add(categories);
                _categoriesService.SaveChanges();
                return Ok(categories.Id);
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
                _categoriesService.Delete(_ => _.Id == id);
                _categoriesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public ActionResult updateName(int id, string name, string description, string img)
        {
            try
            {
                Categories categories = _categoriesService.Get(_ => _.Id == id);
                if (categories == null) throw new Exception();
                categories.Name = name;
                categories.Description = description;
                categories.Img = img;


                _categoriesService.Update(categories);
                _categoriesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}