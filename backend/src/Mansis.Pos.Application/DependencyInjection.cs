using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mansis.Pos.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(ApplicationAssembly.Assembly));

        services.AddValidatorsFromAssembly(ApplicationAssembly.Assembly);

        return services;
    }
}
