using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Storage.Implementations;
using Infrastructure.Storage.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
    {
        services.AddScoped<ILivroRepository, LivroRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        services.AddHttpClient<IArmazenamentoService, SupabaseArmazenamentoService>();

        return services;
    }
}
