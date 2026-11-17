using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BookLogApi.Extensions;

public static class ClaimsPrincipalExtensions
{
    // Pega o Id do usuário logado de dentro do token (claim "sub")
    public static int ObterUsuarioId(this ClaimsPrincipal user)
        => int.Parse(user.FindFirstValue(JwtRegisteredClaimNames.Sub)!);
}
