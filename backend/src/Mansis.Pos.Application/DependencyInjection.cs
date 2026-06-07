using FluentValidation;
using Mansis.Pos.Application.Auth;
using Mansis.Pos.Application.Core;
using Mansis.Pos.Application.Loyalty;
using Mansis.Pos.Application.Loyalty.RedeemReward;
using Mansis.Pos.Application.Orders.CancelOrder;
using MediatR;
using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Application.Pos;
using Microsoft.Extensions.DependencyInjection;

namespace Mansis.Pos.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(ApplicationAssembly.Assembly));

        services.AddValidatorsFromAssembly(ApplicationAssembly.Assembly);
        services.AddScoped<AuthService>();
        services.AddScoped<CoreCrudService>();
        services.AddScoped<CampaignEvaluator>();
        services.AddScoped<LoyaltyEarnCalculator>();
        services.AddScoped<RedeemRewardService>();
        services.AddScoped<CancelOrderService>();
        services.AddScoped<CreateOrderService>();
        services.AddScoped<PosService>();

        return services;
    }
}
