
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController()
        {
            _service = new CustomerService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CustomerDTO>> GetAll()
        {
            var list = _service.GetAll();
            if (list == null || list.Count == 0)
                return NoContent();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound("Customer with ID " + id + " not found.");
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Register([FromBody] CustomerDTO dto)
        {
            if (!_service.Register(dto))
                return BadRequest("Insert failed.");
            return Ok("Created successfully.");
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<CustomerDTO> Login([FromBody] LoginRequest login)
        {
            var customer = _service.Login(login.Email, login.Password);
            if (customer == null)
                return Unauthorized("Invalid email or password.");

            return Ok(customer);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] CustomerDTO dto)
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
