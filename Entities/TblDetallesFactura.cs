﻿namespace FacturaWilmer.Entities;

public partial class TblDetallesFactura
{
    public int Id { get; set; }

    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    public int CantidadDeProducto { get; set; }

    public decimal PrecioUnitarioProducto { get; set; }

    public decimal SubtotalProducto { get; set; }

    public string? Notas { get; set; }

    public virtual TblFactura IdFacturaNavigation { get; set; } = null!;

    public virtual CatProducto IdProductoNavigation { get; set; } = null!;
}
