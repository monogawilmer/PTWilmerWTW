using FacturaWilmer.DTOs;
using FacturaWilmer.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWilmer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearFactura([FromBody] CrearFacturaDto dto)
        {
            try
            {
                await _facturaService.CrearFacturaAsync(dto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Se ha presentado un error, por favor comunicarse con soporte.");
            }
        }
    }
}
