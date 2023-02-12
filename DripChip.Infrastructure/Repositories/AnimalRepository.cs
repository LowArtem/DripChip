using DripChip.Core.Entities;
using DripChip.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DripChip.Infrastructure.Repositories;

public class AnimalRepository : EfRepository<Animal, long>
{
    public AnimalRepository(ApplicationContext context) : base(context)
    {
    }

    public override IQueryable<Animal> Items => base.Items
        .Include(i => i.Chipper)
        .Include(i => i.AnimalTypes)
        .Include(i => i.ChippingLocation)
        .Include(i => i.VisitedLocations);
}