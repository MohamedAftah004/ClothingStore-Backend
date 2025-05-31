
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsService _service;

        public OrderDetailsController()
        {
            _service = new OrderDetailsService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OrderDetailsDTO>> GetAll()
        {
            var list = _service.GetAll();
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDetailsDTO> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound("OrderDetails with ID " + id + " not found.");
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] OrderDetailsDTO dto)
        {
            if (!_service.Insert(dto))
                return BadRequest("Insert failed.");
            return Ok("Created successfully.");
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] OrderDetailsDTO dto)
        {
            dto.Id = id;
            if (!_service.Update(dto))
                return BadRequest("Update failed.");
            return Ok("Updated successfully.");
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
