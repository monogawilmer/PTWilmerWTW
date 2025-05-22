namespace FacturaWilmer.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public string TipoCliente { get; set; } = null!;
    }
}
