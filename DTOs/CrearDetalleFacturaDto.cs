namespace FacturaWilmer.DTOs
{
    public class CrearDetalleFacturaDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string? Notas { get; set; }
    }
}
