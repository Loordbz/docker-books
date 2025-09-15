using Domain.Interface.Service;
using Infra.Data.Context;
using Infra.Repository;
using Service.Service;

namespace Books.Api.configurations;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddScoped<IBooksService, BooksService>();
        services.AddSingleton<Db>();
    }

    public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddScoped<IBooksRepository, BooksRepository>();
    }
}