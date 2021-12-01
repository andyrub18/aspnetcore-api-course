using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("publisher")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var _result = _publisherService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publisherService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher Name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("publisher/{id}")]
        public IActionResult GetPublisher(int id)
        {
            var _response = _publisherService.GetPublisher(id);
            if(_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("publisherData/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            try
            {
                _publisherService.DeletePublisher(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
