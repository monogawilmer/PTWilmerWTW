using FacturaWilmer.Data;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<TblFactura>> ObtenerFacturas(int? idCliente, int? numeroFactura)
        {
            try
            {
                List<TblFactura> listaFactura = new List<TblFactura>();
                listaFactura = await (idCliente != null ?
                                                        _context.TblFacturas.Where(x => x.IdCliente == idCliente).ToListAsync() : 
                                                        _context.TblFacturas.Where(x => x.NumeroFactura == numeroFactura).ToListAsync());
                return listaFactura;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }
    }
}
