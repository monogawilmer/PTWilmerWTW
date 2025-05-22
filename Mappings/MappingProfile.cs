using AutoMapper;
using FacturaWilmer.DTOs;
using FacturaWilmer.Entities;

namespace FacturaWilmer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblCliente, ClienteDto>()
                .ForMember(dest => dest.TipoCliente, opt => opt.MapFrom(src => src.IdTipoClienteNavigation.TipoCliente));

            CreateMap<CatProducto, ProductoDto>().ForMember(dest => dest.ImagenBase64,
                                                        opt => opt.MapFrom(src =>
                                                            src.ImagenProducto != null
                                                                ? $"data:image/{src.Ext};base64,{Convert.ToBase64String(src.ImagenProducto)}"
                                                                : null));
        }
    }
}
