using Application.DTOs.Usuario;
using Application.Helpers;
using Application.Response;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Storage.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Implementations;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IArmazenamentoService _armazenamento;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repository, IArmazenamentoService armazenamento, IMapper mapper)
    {
        _repository = repository;
        _armazenamento = armazenamento;
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

    public async Task<Response<UsuarioDto>> AtualizarFoto(int id, IFormFile arquivo)
    {
        try
        {
            var erroImagem = ImagemHelper.Validar(arquivo);

            if (erroImagem is not null)
                return Response<UsuarioDto>.Error(erroImagem);

            var usuario = await _repository.GetById(id);

            if (usuario is null)
                return Response<UsuarioDto>.NotFound("Usuário não encontrado.");

            var caminho = $"usuarios/{id}/{ImagemHelper.GerarNomeArquivo(arquivo)}";

            await using var conteudo = arquivo.OpenReadStream();
            var novaUrl = await _armazenamento.Enviar(conteudo, caminho, arquivo.ContentType);

            var fotoAntiga = usuario.FotoUrl;
            usuario.FotoUrl = novaUrl;

            _repository.Update(usuario);
            await _repository.SaveChangesAsync();

            // Remove a foto antiga do Storage (se falhar, não impede a troca)
            if (fotoAntiga is not null)
            {
                try { await _armazenamento.Remover(fotoAntiga); } catch { }
            }

            var usuarioMapeado = _mapper.Map<UsuarioDto>(usuario);

            return Response<UsuarioDto>.Success(usuarioMapeado, "Foto atualizada com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<UsuarioDto>.Error(ex.Message);
        }
    }
}
