using FacturaWilmer.Data;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FacturaWilmer.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DevLabContext _context;

        public ClienteRepository(DevLabContext context)
        {
            _context = context;
        }

        public async Task<List<TblCliente>> GetClientesAsync()
        {
            try
            {
                return await _context.TblClientes.Include(c => c.IdTipoClienteNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }
    }
}
