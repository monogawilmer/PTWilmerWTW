namespace FacturaWilmer.Entities;

public partial class CatTipoCliente
{
    public int Id { get; set; }

    public string TipoCliente { get; set; } = null!;

    public virtual ICollection<TblCliente> TblClientes { get; set; } = new List<TblCliente>();
}
