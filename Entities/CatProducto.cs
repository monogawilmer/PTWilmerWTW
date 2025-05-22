namespace FacturaWilmer.Entities;

public partial class CatProducto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public byte[]? ImagenProducto { get; set; }

    public decimal PrecioUnitario { get; set; }

    public string? Ext { get; set; }

    public virtual ICollection<TblDetallesFactura> TblDetallesFacturas { get; set; } = new List<TblDetallesFactura>();
}
