using FacturaWilmer.Data;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FacturaWilmer.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DevLabContext _context;

        public ProductoRepository(DevLabContext context)
        {
            _context = context;
        }

        public async Task<List<CatProducto>> GetProductosAsync()
        {
            try
            {
                return await _context.CatProductos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }
    }
}
