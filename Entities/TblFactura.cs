namespace FacturaWilmer.Entities;

public partial class TblFactura
{
    public int Id { get; set; }

    public DateTime FechaEmisionFactura { get; set; }

    public int IdCliente { get; set; }

    public int NumeroFactura { get; set; }

    public int NumeroTotalArticulos { get; set; }

    public decimal SubTotalFacturas { get; set; }

    public decimal TotalImpuestos { get; set; }

    public decimal TotalFactura { get; set; }

    public virtual TblCliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TblDetallesFactura> TblDetallesFacturas { get; set; } = new List<TblDetallesFactura>();
}
