using AutoMapper;
using DTOs;
using Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUsuario, Usuario>();
    }
}
