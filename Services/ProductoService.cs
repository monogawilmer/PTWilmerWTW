using AutoMapper;
using FacturaWilmer.DTOs;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;
using FacturaWilmer.Interfaces.IServices;

namespace FacturaWilmer.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> ObtenerProductosAsync()
        {
            try
            {
                List<CatProducto> productos = await _productoRepository.GetProductosAsync();
                return _mapper.Map<List<ProductoDto>>(productos);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
