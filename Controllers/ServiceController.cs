using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vechicalManagement.Data;
using vechicalManagement.Models;
namespace vechicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class ServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
         
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> updateStatus(int id, [FromBody] string status)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return BadRequest("Vehicle is not present");
            }
            vehicle.Status = status;
            await _context.SaveChangesAsync();
            return Ok(vehicle);
        }
    }
}
