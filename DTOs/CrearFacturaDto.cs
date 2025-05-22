namespace FacturaWilmer.DTOs
{
    public class CrearFacturaDto
    {
        public int IdCliente { get; set; }
        public int NumeroFactura { get; set; }
        public List<CrearDetalleFacturaDto> Detalles { get; set; } = new();
    }
}
