using Application.DTOs.Usuario;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<UpdateUsuarioDto, Usuario>();
    }
}
