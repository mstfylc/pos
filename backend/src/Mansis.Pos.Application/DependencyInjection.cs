using FluentValidation;
using MediatR;
using Mansis.Pos.Application.Orders.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

namespace Mansis.Pos.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(ApplicationAssembly.Assembly));

        services.AddValidatorsFromAssembly(ApplicationAssembly.Assembly);
        services.AddScoped<CreateOrderService>();

        return services;
    }
}
