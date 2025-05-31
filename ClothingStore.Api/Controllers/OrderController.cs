using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController()
        {
            _service = new OrderService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OrderDTO>> GetAll()
        {
            var list = _service.GetAll();
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound("Order with ID " + id + " not found.");
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] OrderDTO dto)
        {
            if (!_service.Insert(dto))
                return BadRequest("Insert failed.");
            return Ok("Created successfully.");
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] OrderDTO dto)
        {
            dto.Id = id;
            if (!_service.Update(dto))
                return BadRequest("Update failed.");
            return Ok("Updated successfully.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound("Delete failed.");
            return Ok("Deleted successfully.");
        }

        // ✅ Get orders by customer ID
        [HttpGet("customer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OrderDTO>> GetByCustomerId(int customerId)
        {
            var list = _service.GetByCustomerId(customerId);
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        // Update payment status
        [HttpPut("{orderId:int}/payment-status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdatePaymentStatus(int orderId, [FromBody] string newStatus)
        {
            if (!_service.UpdatePaymentStatus(orderId, newStatus))
                return BadRequest("Failed to update payment status.");
            return Ok("Payment status updated.");
        }

        // Cancel order
        [HttpPut("{orderId:int}/cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Cancel(int orderId)
        {
            if (!_service.Cancel(orderId))
                return BadRequest("Failed to cancel order.");
            return Ok("Order cancelled successfully.");
        }
    }
}
