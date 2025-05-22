using FacturaWilmer.DTOs;

namespace FacturaWilmer.Interfaces.IServices
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> ObtenerClientesAsync();
    }
}
