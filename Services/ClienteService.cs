using AutoMapper;
using FacturaWilmer.DTOs;
using FacturaWilmer.Entities;
using FacturaWilmer.Interfaces.IRepositories;
using FacturaWilmer.Interfaces.IServices;

namespace FacturaWilmer.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDto>> ObtenerClientesAsync()
        {
            try
            {
                List<TblCliente> clientes = await _clienteRepository.GetClientesAsync();
                return _mapper.Map<List<ClienteDto>>(clientes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }
    }
}
