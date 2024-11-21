using DavxeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DavxeShop.Api
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("flightData")]
        public IActionResult PostFlightData([FromBody] FlightData flightData)
        {
            if (flightData == null)
            {
                return BadRequest("Los datos del vuelo son inválidos.");
            }

            //crear un metodo que te lleve a la library sabes 

            return Ok(new { message = "Datos de vuelo recibidos correctamente", flightData });
        }
    }
}
