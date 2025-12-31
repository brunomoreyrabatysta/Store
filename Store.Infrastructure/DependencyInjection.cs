using Store.Domain.Repositories;
using Store.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Abstractions;
using Store.Infrastructure.Data;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IProductRepository, ProductRepository>();
        return services;
    }
}
