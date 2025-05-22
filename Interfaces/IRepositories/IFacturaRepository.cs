using FacturaWilmer.Entities;

namespace FacturaWilmer.Interfaces.IRepositories
{
    public interface IFacturaRepository
    {
        Task CrearFacturaAsync(TblFactura factura);
    }
}
