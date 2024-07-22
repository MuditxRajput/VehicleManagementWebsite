using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vechicalManagement.Data;
using vechicalManagement.Models;

namespace vechicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)

        {
            _context = context;
        }
        [HttpPost("addVehicle")]

        public async Task<IActionResult> addVechicle(Vehicle vehicle)
        {
            try
            {
                // check the vehicle is already add or not...
                var existedVehicle = _context.Vehicles.FirstOrDefault(u => u.PlateNumber == vehicle.PlateNumber);
                if (existedVehicle != null)
                {
                    return BadRequest("Vehicle is already exist");
                }
                var vehicleFromDatabase = _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Vehicle is added" });

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpDelete("deleteVehicle")]

        public async Task<IActionResult> deleteVehicle(int id)
        {
            try
            {
                var existedVehicle = _context.Vehicles.FirstOrDefault(u => u.Id == id);
                if (existedVehicle == null)
                {
                    return BadRequest("Vehicle is not found...");
                }
                _context.Vehicles.Remove(existedVehicle);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Vehicle is delete" });
            }
            catch (Exception ex)
            {
                {
                    return Ok(ex);
                }
            }
        }


        [HttpPost("updateVehicle")]
        public async Task<IActionResult> updateVehicle(int id, [FromBody] Vehicle vehicle)
        {
            try
            {
                var existedVehicle = _context.Vehicles.FirstOrDefault(u => u.Id == id);
                if (existedVehicle == null)
                {
                    return BadRequest("Vechicle is not found");
                }
                existedVehicle.Status = vehicle.Status;
                existedVehicle.PlateNumber = vehicle.PlateNumber;
                existedVehicle.ServiceEndDate = vehicle.ServiceEndDate;
                existedVehicle.VehicleName = vehicle.VehicleName;
                existedVehicle.ServiceStartDate = vehicle.ServiceStartDate;
                existedVehicle.CustomerName = vehicle.CustomerName;
                existedVehicle.WorkerId = vehicle.WorkerId;

                _context.Vehicles.Update(existedVehicle);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Vehicle update successfully" });
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet("allVehicle")]

        public async Task<IActionResult> GetVehicles()
        {
            try
            {
                var vehicles = await _context.Vehicles.ToListAsync();
                if (vehicles == null || !vehicles.Any())
                {
                    return NotFound("No vehicles found");
                }
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving vehicles: {ex.Message}");
            }
        }
    }
}
