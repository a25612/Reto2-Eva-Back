using AutoMapper;
using DTOs;
using Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioDTO>();
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<CreateUsuarioDTO, Usuario>();
    }
}
