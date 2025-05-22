using FacturaWilmer.Entities;

namespace FacturaWilmer.Interfaces.IRepositories
{
    public interface IFacturaRepository
    {
        Task CrearFacturaAsync(TblFactura factura);

        Task<List<TblFactura>> ObtenerFacturas(int? idCliente, int? numeroFactura);
    }
}
