using FacturaWilmer.Data;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;

namespace FacturaWilmer.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly DevLabContext _context;

        public FacturaRepository(DevLabContext context)
        {
            _context = context;
        }

        public async Task CrearFacturaAsync(TblFactura factura)
        {
            try
            {
                _context.TblFacturas.Add(factura);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }
    }
}
