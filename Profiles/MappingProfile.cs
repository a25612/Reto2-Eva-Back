using AutoMapper;
using DTOs;
using Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, Usuario>();
        CreateMap<Usuario, Usuario>();
        CreateMap<CreateUsuario, Usuario>();
    }
}
