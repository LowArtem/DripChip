using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Entities;

public class VisitedLocation : BaseEntity<long>
{
    public DateTime DateTimeOfVisitLocationPoint { get; set; }
    public virtual AnimalLocationPoint LocationPoint { get; set; } = null!;
}