using FacturaWilmer.DTOs;
using FacturaWilmer.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWilmer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> Get()
        {
            try
            {
                return await _productoService.ObtenerProductosAsync();
            }
            catch (Exception)
            {
                return BadRequest("Se ha presentado un error, por favor comunicarse con soporte.");
            }
        }
    }
}
