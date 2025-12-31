using Microsoft.Extensions.DependencyInjection;

namespace Store.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(x =>
        { 
            x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
}
