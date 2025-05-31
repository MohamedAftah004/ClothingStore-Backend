using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Business;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStoreApi.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _service;

        public AdminController()
        {
            _service = new AdminService();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<AdminDTO>> GetAdmins()
        {
            var list = _service.GetAll();
            if (list == null || list.Count == 0)
                return NoContent();

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AdminDTO> GetAdminById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound($"Admin with ID {id} not found.");

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateAdmin([FromBody] AdminDTO dto)
        {
            if (!_service.Insert(dto))
                return BadRequest("Insert failed.");

            return Ok("Admin created successfully.");
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateAdmin(int id, [FromBody] AdminDTO dto)
        {
            dto.Id = id;
            if (!_service.Update(dto))
                return BadRequest("Update failed.");

            return Ok("Admin updated successfully.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteAdmin(int id)
        {
            if (!_service.Delete(id))
                return NotFound("Delete failed.");

            return Ok("Admin deleted successfully.");
        }
    }
}
