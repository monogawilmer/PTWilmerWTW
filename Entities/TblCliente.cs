namespace FacturaWilmer.Entities;

public partial class TblCliente
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public int IdTipoCliente { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public string Rfc { get; set; } = null!;

    public virtual CatTipoCliente IdTipoClienteNavigation { get; set; } = null!;

    public virtual ICollection<TblFactura> TblFacturas { get; set; } = new List<TblFactura>();
}
