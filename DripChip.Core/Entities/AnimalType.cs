using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Entities;

public class AnimalType : BaseEntity<long>
{
    public string Type { get; set; }
}