using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Entities;

public class AnimalLocationPoint : BaseEntity<long>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}