using DripChip.Core.Entities;
using DripChip.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DripChip.Infrastructure.Repositories;

public static class RepositoryDi
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddScoped<IRepository<Animal, long>, AnimalRepository>()
        .AddScoped<IRepository<AnimalLocationPoint, long>, EfRepository<AnimalLocationPoint, long>>()
        .AddScoped<IRepository<AnimalType, long>, EfRepository<AnimalType, long>>()
        .AddScoped<IRepository<User, int>, EfRepository<User, int>>()
        .AddScoped<IRepository<VisitedLocation, long>, EfRepository<VisitedLocation, long>>();
}