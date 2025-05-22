namespace FacturaWilmer.DTOs
{
    public class FacturaDto
    {
        public int Id { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public int NumeroFactura { get; set; }
        public decimal TotalFactura { get; set; }
    }
}
