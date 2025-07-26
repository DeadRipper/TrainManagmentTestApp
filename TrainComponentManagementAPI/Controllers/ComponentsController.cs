using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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
            if (!await _service.CheckIfComponentIsNotEmpty(id, comp)) 
                return NotFound();
            return Ok(comp);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPut("{id}/assignQuantity")]
        public async Task<IActionResult> AssignQuantity(int id, AssignQuantity requestBody)
        {
            if (requestBody.Quantity <= 0)
                return BadRequest("Quantity must be a positive integer.");

            var component = await _service.FindComponent(_context, id);
            if (!await _service.CheckIfComponentIsNotEmpty(id, component)) 
                return NotFound();
            //make StringComparison.Ordinal to compare lower\upper case of Yes and No. By task Yas and No always in uppercase
            if (string.Compare(component.CanAssignQuantity, "No", StringComparison.Ordinal) == 0)
                return BadRequest("Quantity cannot be assigned to this component.");

            component.Quantity = requestBody.Quantity;
            await _service.SavedContextInDB(_context);

            return Ok();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPut("updateComponent")]
        public async Task<IActionResult> UpdateComponent(TrainComponent requestBody)
        {
            var updateComponent = await _service.UpdateComponent(_context, requestBody);

            if (updateComponent == null)
            {
                return BadRequest("Error in execution of updateComponent");
            }

            return Ok();
        }
    }
}