using Application.DTOs.Usuario;
using Application.Response;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services.Implementations;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<UsuarioDto>> GetById(int id)
    {
        try
        {
            var usuario = await _repository.GetById(id);

            if (usuario is null)
                return Response<UsuarioDto>.NotFound("Usuário não encontrado.");

            var usuarioMapeado = _mapper.Map<UsuarioDto>(usuario);

            return Response<UsuarioDto>.Success(usuarioMapeado, "Usuário exibido com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<UsuarioDto>.Error(ex.Message);
        }
    }

    public async Task<Response<UsuarioDto>> Update(int id, UpdateUsuarioDto dto)
    {
        try
        {
            var usuario = await _repository.GetById(id);

            if (usuario is null)
                return Response<UsuarioDto>.NotFound("Usuário não encontrado.");

            _mapper.Map(dto, usuario);

            _repository.Update(usuario);
            await _repository.SaveChangesAsync();

            var usuarioMapeado = _mapper.Map<UsuarioDto>(usuario);

            return Response<UsuarioDto>.Success(usuarioMapeado, "Usuário atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<UsuarioDto>.Error(ex.Message);
        }
    }
}
