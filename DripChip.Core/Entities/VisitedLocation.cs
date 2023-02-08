using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Entities;

public class VisitedLocation : BaseEntity<long>
{
    public DateTime DateTimeOfVisitLocationPoint { get; set; }
    public AnimalLocationPoint LocationPoint { get; set; }
}