using FacturaWilmer.DTOs;

namespace FacturaWilmer.Interfaces.IServices
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> ObtenerProductosAsync();
    }
}
