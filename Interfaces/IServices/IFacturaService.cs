using FacturaWilmer.DTOs;

namespace FacturaWilmer.Interfaces.IServices
{
    public interface IFacturaService
    {
        Task CrearFacturaAsync(CrearFacturaDto dto);
    }
}
