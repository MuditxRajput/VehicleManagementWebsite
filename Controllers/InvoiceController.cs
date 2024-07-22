using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vechicalManagement.Data;

namespace vechicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
       // [HttpPost("Invoice")]

        // public async Task<IActionResult> invoice(int id, int price)
        //{
        //  try
        //  {
        //   var vehicleDetail = _context.Vehicles.FirstOrDefault(x=>x.Id== id);
        //   if (vehicleDetail == null)
        //       {
        //     return BadRequest("Vehicle is not present");
        //       }

        //   }
        //   catch (Exception ex)
        //   {


        //   }

        //}

    }
}

