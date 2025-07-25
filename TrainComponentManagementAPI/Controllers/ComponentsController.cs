using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;

namespace TrainComponentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentsController : ControllerBase
    {
        private readonly TrainDbContext _context;

        public ComponentsController(TrainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            return await _context.Components
                .Select(c => new Component
                {
                    Id = c.Id,
                    Name = c.Name,
                    UniqueNumber = c.UniqueNumber,
                    CanAssignQuantity = c.CanAssignQuantity,
                    Quantity = c.Quantity
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
            var comp = await _context.Components.FindAsync(id);
            if (comp == null) return NotFound();

            return new Component
            {
                Id = comp.Id,
                Name = comp.Name,
                UniqueNumber = comp.UniqueNumber,
                CanAssignQuantity = comp.CanAssignQuantity,
                Quantity = comp.Quantity
            };
        }

        [HttpPut("{id}/assign-quantity")]
        public async Task<IActionResult> AssignQuantity(int id, AssignQuantity requestBody)
        {
            if (requestBody.Quantity <= 0)
                return BadRequest("Quantity must be a positive integer.");

            var component = await _context.Components.FindAsync(id);
            if (component == null) 
                return NotFound();
            if (string.Compare(component.CanAssignQuantity, "No", StringComparison.OrdinalIgnoreCase) == 0)
                return BadRequest("Quantity cannot be assigned to this component.");

            component.Quantity = requestBody.Quantity;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}