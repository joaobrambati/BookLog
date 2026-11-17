using Application.DTOs.Auth;
using Application.DTOs.Usuario;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<RegistrarDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>();
    }
}
