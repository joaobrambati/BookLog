using Application.DTOs.Livro;
using Application.Response;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services.Implementations;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _repository;
    private readonly IMapper _mapper;

    public LivroService(ILivroRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<LivroDto>>> GetAll()
    {
        try
        {
            var livros = await _repository.GetAll();

            if (!livros.Any())
                return Response<List<LivroDto>>.NotFound("Livros não encontrados.");

            var livrosMapeados = _mapper.Map<List<LivroDto>>(livros);

            return Response<List<LivroDto>>.Success(livrosMapeados, "Livros listados com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<List<LivroDto>>.Error(ex.Message);
        }
    }

    public async Task<Response<LivroDto>> GetById(int id)
    {
        try
        {
            var livro = await _repository.GetById(id);

            if (livro is null)
                return Response<LivroDto>.NotFound("Livro não encontrado.");

            var livroMapeado = _mapper.Map<LivroDto>(livro);

            return Response<LivroDto>.Success(livroMapeado, "Livro exibido com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<LivroDto>.Error(ex.Message);
        }
    }

    public async Task<Response<LivroDto>> Create(CreateLivroDto dto)
    {
        try
        {
            var livro = _mapper.Map<Livro>(dto);

            await _repository.Create(livro);
            await _repository.SaveChangesAsync();

            var livroMapeado = _mapper.Map<LivroDto>(livro);

            return Response<LivroDto>.Success(livroMapeado, "Livro cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<LivroDto>.Error(ex.Message);
        }
    }

    public async Task<Response<LivroDto>> Update(int id, UpdateLivroDto dto)
    {
        try
        {
            var livro = await _repository.GetById(id);

            if (livro is null)
                return Response<LivroDto>.NotFound("Livro não encontrado.");

            _mapper.Map(dto, livro);

            _repository.Update(livro);
            await _repository.SaveChangesAsync();

            var livroMapeado = _mapper.Map<LivroDto>(livro);

            return Response<LivroDto>.Success(livroMapeado, "Livro atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<LivroDto>.Error(ex.Message);
        }
    }

    public async Task<Response<bool>> Delete(int id)
    {
        try
        {
            var livro = await _repository.GetById(id);

            if (livro is null)
                return new Response<bool> { Status = false, Message = "Livro não encontrado." };

            _repository.Delete(livro);
            await _repository.SaveChangesAsync();

            return new Response<bool> { Status = true, Message = "Livro deletado com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<bool> { Status = false, Message = ex.Message };
        }
    }
     
}
