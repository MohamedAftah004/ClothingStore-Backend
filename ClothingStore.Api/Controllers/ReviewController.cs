using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;

        public ReviewController()
        {
            _service = new ReviewService();
        }

        // Admin only
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ReviewDTO>> GetAll()
        {
            var list = _service.GetAll();
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReviewDTO> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound("Review with ID " + id + " not found.");
            return Ok(item);
        }

        // Get reviews for a specific product
        [HttpGet("product/{productId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ReviewDTO>> GetByProductId(int productId)
        {
            var list = _service.GetByProductId(productId);
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        // Get reviews written by a specific customer
        [HttpGet("customer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ReviewDTO>> GetByCustomerId(int customerId)
        {
            var list = _service.GetByCustomerId(customerId);
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        // Check if a review exists for given customer and product
        [HttpGet("exists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> Exists([FromQuery] int customerId, [FromQuery] int productId)
        {
            var exists = _service.Exists(customerId, productId);
            return Ok(exists);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] ReviewDTO dto)
        {
            if (!_service.Insert(dto))
                return BadRequest("Insert failed.");
            return Ok("Created successfully.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound("Delete failed.");
            return Ok("Deleted successfully.");
        }
    }
}
