using FacturaWilmer.Entities;

namespace FacturaWilmer.Interfaces.IRepositories
{
    public interface IClienteRepository
    {
        Task<List<TblCliente>> GetClientesAsync();
    }
}
