using DripChip.Core.Services.Common;
using DripChip.Infrastructure.Services.Common;
using Microsoft.Extensions.DependencyInjection;

namespace DripChip.Infrastructure.Services;

public static class ServiceDi
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddScoped<IUserService, UserService>();
}