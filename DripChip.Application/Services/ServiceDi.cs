using DripChip.Application.Services.Common;
using Microsoft.Extensions.DependencyInjection;

namespace DripChip.Application.Services;

public static class ServiceDi
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddScoped<IUserService, UserService>();
}