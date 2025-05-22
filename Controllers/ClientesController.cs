using FacturaWilmer.DTOs;
using FacturaWilmer.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWilmer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> Get()
        {
            try
            {
                return await _clienteService.ObtenerClientesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Se ha presentado un error, por favor comunicarse con soporte.");
            }
        }
    }
}
