using Application.DTOs.Auth;
using Application.Response;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IMapper _mapper;

    public AuthService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IPasswordHasher<Usuario> passwordHasher, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<Response<AuthResponseDto>> Registrar(RegistrarDto dto)
    {
        try
        {
            dto.Email = dto.Email.Trim().ToLowerInvariant();

            var usuarioExistente = await _usuarioRepository.GetByEmail(dto.Email);

            if (usuarioExistente is not null)
                return Response<AuthResponseDto>.Error("Já existe um usuário com este email.");

            var usuario = _mapper.Map<Usuario>(dto);
            usuario.SenhaHash = _passwordHasher.HashPassword(usuario, dto.Senha);

            await _usuarioRepository.Create(usuario);
            await _usuarioRepository.SaveChangesAsync();

            return Response<AuthResponseDto>.Success(GerarResposta(usuario), "Usuário cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<AuthResponseDto>.Error(ex.Message);
        }
    }

    public async Task<Response<AuthResponseDto>> Login(LoginDto dto)
    {
        try
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            var usuario = await _usuarioRepository.GetByEmail(email);

            if (usuario is null || usuario.SenhaHash is null)
                return Response<AuthResponseDto>.Error("Email ou senha inválidos.");

            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.SenhaHash, dto.Senha);

            if (resultado == PasswordVerificationResult.Failed)
                return Response<AuthResponseDto>.Error("Email ou senha inválidos.");

            return Response<AuthResponseDto>.Success(GerarResposta(usuario), "Login realizado com sucesso.");
        }
        catch (Exception ex)
        {
            return Response<AuthResponseDto>.Error(ex.Message);
        }
    }

    private AuthResponseDto GerarResposta(Usuario usuario)
    {
        var (token, expiracao) = _tokenService.GerarToken(usuario);

        return new AuthResponseDto
        {
            Token = token,
            Expiracao = expiracao
        };
    }
}
