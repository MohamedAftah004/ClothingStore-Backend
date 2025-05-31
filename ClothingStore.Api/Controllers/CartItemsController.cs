
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/cart-items")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly CartItemsService _service;

        public CartItemsController()
        {
            _service = new CartItemsService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CartItemDTO>> GetAllCartItems()
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
                return StatusCode(500, $"Error fetching cart items: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CartItemDTO> GetCartItemById(int id)
        {
            try
            {
                var item = _service.GetById(id);
                if (item == null)
                    return NotFound($"Cart item with ID {id} not found.");

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching cart item: {ex.Message}");
            }
        }

        [HttpGet("cart/{cartId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CartItemDTO>> GetItemsByCartId(int cartId)
        {
            try
            {
                var list = _service.GetByCartId(cartId);
                if (list == null || list.Count == 0)
                    return NoContent();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching cart items for cart ID {cartId}: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateCartItem([FromBody] CartItemDTO dto)
        {
            try
            {
                if (!_service.Insert(dto))
                    return BadRequest("Failed to create cart item.");

                return CreatedAtAction(nameof(GetCartItemById), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating cart item: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateCartItem(int id, [FromBody] CartItemDTO dto)
        {
            try
            {
                dto.Id = id;
                if (!_service.Update(dto))
                    return BadRequest("Update failed.");

                return Ok("Cart item updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating cart item: {ex.Message}");
            }
        }

        [HttpDelete("cart/{cartId:int}/clear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult ClearCartByCartId(int cartId)
        {
            try
            {
                if (!_service.ClearCart(cartId))
                    return NotFound("Cart not found or already empty.");

                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error clearing cart: {ex.Message}");
            }
        }
    }

}
