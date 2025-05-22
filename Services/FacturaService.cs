using AutoMapper;
using FacturaWilmer.Data;
using FacturaWilmer.DTOs;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;
using FacturaWilmer.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace FacturaWilmer.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly DevLabContext _context;

        public FacturaService(IFacturaRepository facturaRepository, DevLabContext context)
        {
            _facturaRepository = facturaRepository;
            _context = context;
        }
        public async Task CrearFacturaAsync(CrearFacturaDto dto)
        {
            try
            {
                TblFactura factura = new TblFactura
                {
                    IdCliente = dto.IdCliente,
                    FechaEmisionFactura = DateTime.Now,
                    NumeroFactura = dto.NumeroFactura,
                    TblDetallesFacturas = new List<TblDetallesFactura>()
                };

                TblFactura? tblFactura = await _context.TblFacturas.FindAsync(factura.NumeroFactura);

                if (tblFactura != null)
                {
                    throw new ApplicationException("Ya existe una factura con este número de factura.");
                }

                decimal subtotal = 0;
                int totalArticulos = 0;

                foreach (var detalle in dto.Detalles)
                {
                    CatProducto? producto = await _context.CatProductos.FindAsync(detalle.IdProducto);

                    if (producto == null) continue;

                    decimal subTotalDetalle = producto.PrecioUnitario * detalle.Cantidad;
                    subtotal += subTotalDetalle;
                    totalArticulos += detalle.Cantidad;

                    factura.TblDetallesFacturas.Add(new TblDetallesFactura
                    {
                        IdProducto = detalle.IdProducto,
                        CantidadDeProducto = detalle.Cantidad,
                        PrecioUnitarioProducto = producto.PrecioUnitario,
                        SubtotalProducto = subTotalDetalle,
                        Notas = detalle.Notas
                    });
                }

                factura.SubTotalFacturas = subtotal;
                factura.TotalImpuestos = subtotal * 0.19m;
                factura.TotalFactura = factura.SubTotalFacturas + factura.TotalImpuestos;
                factura.NumeroTotalArticulos = totalArticulos;

                await _facturaRepository.CrearFacturaAsync(factura);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
