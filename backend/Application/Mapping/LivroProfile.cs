using Application.DTOs.Livro;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<Livro, LivroDto>();
        CreateMap<CreateLivroDto, Livro>();
        CreateMap<UpdateLivroDto, Livro>();
    }
}
