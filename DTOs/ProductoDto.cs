namespace FacturaWilmer.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public string ImagenBase64 { get; set; } = null!;
    }
}
