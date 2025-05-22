using FacturaWilmer.DTOs;
using FacturaWilmer.Entities;

namespace FacturaWilmer.Interfaces.IServices
{
    public interface IFacturaService
    {
        Task CrearFacturaAsync(CrearFacturaDto dto);

        Task<List<FacturaDto>> ObtenerFacturas(int? idCliente, int? numeroFactura);
    }
}
