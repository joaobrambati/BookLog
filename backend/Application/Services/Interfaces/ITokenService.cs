using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ITokenService
{
    (string Token, DateTime Expiracao) GerarToken(Usuario usuario);
}
