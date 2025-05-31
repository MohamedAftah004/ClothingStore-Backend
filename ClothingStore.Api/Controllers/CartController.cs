using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _service;

        public CartController()
        {
            _service = new CartService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CartDTO>> GetAllCarts()
        {
            try
            {
                var list = _service.GetAll();
                if (list == null || list.Count == 0)
                    return NoContent();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving carts: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CartDTO> GetCartById(int id)
        {
            try
            {
                var item = _service.GetById(id);
                if (item == null)
                    return NotFound($"Cart with ID {id} not found.");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving cart: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateCart(int id, [FromBody] CartDTO dto)
        {
            try
            {
                dto.Id = id;
                if (!_service.Update(dto))
                    return BadRequest("Update failed.");
                return Ok("Cart updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating cart: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCart(int id)
        {
            try
            {
                if (!_service.Delete(id))
                    return NotFound("Delete failed. Cart not found.");
                return Ok("Cart deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting cart: {ex.Message}");
            }
        }

        [HttpGet("customer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CartDTO> GetCartByCustomerId(int customerId)
        {
            try
            {
                var cart = _service.GetByCustomerId(customerId);
                if (cart == null)
                    return NotFound($"No cart found for customer ID {customerId}.");
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving cart: {ex.Message}");
            }
        }

        [HttpGet("customer/{customerId:int}/exists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DoesCartExistForCustomer(int customerId)
        {
            try
            {
                return Ok(_service.ExistsForCustomer(customerId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error checking cart existence: {ex.Message}");
            }
        }

        [HttpPost("customer/{customerId:int}/create-if-not-exists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CartDTO> CreateCartIfNotExists(int customerId)
        {
            try
            {
                var cart = _service.CreateIfNotExists(customerId);
                if (cart == null)
                    return BadRequest("Failed to create cart.");
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating cart: {ex.Message}");
            }
        }
    }

}
