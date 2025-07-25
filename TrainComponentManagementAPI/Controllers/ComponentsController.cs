using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;
using TrainComponentManagementAPI.TrainManagmentWorker;

namespace TrainComponentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentsController(TrainDbContext _context, ITrainManagmentService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainComponent>>> GetComponents()
        {
            var lostOfComponents = await _service.GetAllComponents(_context);
            if (lostOfComponents == null || lostOfComponents?.Count == 0)
            {
                return NotFound();
            }
            return Ok(lostOfComponents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainComponent>> GetComponent(int id)
        {
            var comp = await _service.FindComponent(_context, id);
            if (comp == null || comp.Id != id || string.IsNullOrWhiteSpace(comp.Name) || string.IsNullOrWhiteSpace(comp.UniqueNumber) || string.IsNullOrWhiteSpace(comp.CanAssignQuantity)) 
                return NotFound();
            return Ok(comp);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPut("{id}/assign-quantity")]
        public async Task<IActionResult> AssignQuantity(int id, AssignQuantity requestBody)
        {
            if (requestBody.Quantity <= 0)
                return BadRequest("Quantity must be a positive integer.");

            var component = await _service.FindComponent(_context, id);
            if (component == null) 
                return NotFound();
            if (string.Compare(component.CanAssignQuantity, "No", StringComparison.OrdinalIgnoreCase) == 0)
                return BadRequest("Quantity cannot be assigned to this component.");

            component.Quantity = requestBody.Quantity;
            await _service.SavedContextInDB(_context);

            return Ok();
        }
    }
}