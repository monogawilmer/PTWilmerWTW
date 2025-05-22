using FacturaWilmer.Entities;

namespace FacturaWilmer.Interfaces.IRepositories
{
    public interface IProductoRepository
    {
        Task<List<CatProducto>> GetProductosAsync();
    }
}
