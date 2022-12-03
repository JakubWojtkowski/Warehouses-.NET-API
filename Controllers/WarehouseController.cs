using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WarehouseAPI.Domain;
using WarehouseAPI.Infrastructure.Warehouses;

namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {

        private readonly IWarehouseService _service;

        public WarehouseController(IWarehouseService service)
        {
            this._service = service;
        }


        // Get all method
        [HttpGet]
        public async Task<ActionResult<List<Warehouse>>> GetAll()
        {
            return await _service.GetAll();
        }

        // Get single object by Id method
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Warehouse>>> GetById(int id)
        {
            var warehouse = await _service.GetById(id);
            if (warehouse == null)
                return BadRequest("Warehouse not found.");

            return Ok(warehouse);
        }


        // Post method
        [HttpPost]
        public async Task<ActionResult<List<Warehouse>>> AddWarehouse(Warehouse warehouse)
        {
            var result = await _service.AddWarehouse(warehouse);

            return Ok(result);
        }


        // Put method
        [HttpPut]
        public async Task<ActionResult<List<Warehouse>>> UpdateWarehouse(int id, Warehouse request)
        {
            var result = await _service.UpdateWarehouse(id, request);
            if (result == null)
                return NotFound("Warehouse not found.");

            return Ok(result);
        }



        // Delete method by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Warehouse>>> DeleteWarehouse(int id)
        {
            var result = await _service.DeleteWarehouse(id);
            if (result == null)
                return NotFound("Warehouse not found.");

            return Ok(result);
        }
    }
}

