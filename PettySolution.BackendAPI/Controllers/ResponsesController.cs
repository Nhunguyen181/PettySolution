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
    public class ResponsesController : ControllerBase
    {
        private readonly IResponsesService _responsesService;

        public ResponsesController(IResponsesService responsesService)
        {
            _responsesService = responsesService;
        }
        [HttpGet]
        public ActionResult getResponse(int id)
        {
            try
            {
                Responses response = _responsesService.Get(_ => _.Id == id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Reponses")]
        public ActionResult getAll()
        {
            try
            {
                List<Responses> responses = _responsesService.GetAll().ToList();
                return Ok(responses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("create")]
        public ActionResult create(DateTime date, string title, string contents, double rating, int productID, int orderProductDetailID, string img)
        {
            try
            {
                Responses response = new Responses
                {
                    Date = date,
                    Title = title,
                    Contents = contents,
                    Rating = rating,
                    ProductId = productID,
                    OrderProductDetailId = orderProductDetailID,
                    Img = img,




                };
                _responsesService.Add(response);
                _responsesService.SaveChanges();
                return Ok(response.Id);
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
                _responsesService.Delete(_ => _.Id == id);
                _responsesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult update(int id, DateTime date, string title, string contents, double rating, int productID, int orderProductDetailID, string img)
        {
            try
            {
                Responses responses = _responsesService.Get(_ => _.Id == id);
                if (responses == null) throw new Exception();
                responses.Date = date;
                responses.Title = title;
                responses.Contents = contents;
                responses.Rating = rating;
                responses.ProductId = productID;
                responses.OrderProductDetailId = orderProductDetailID;


                _responsesService.Update(responses);
                _responsesService.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}