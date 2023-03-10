using DripChip.Core.Entities.Abstract;
using DripChip.Core.Enums;

namespace DripChip.Core.Entities;

public class Animal : BaseEntity<long>
{
    public virtual List<AnimalType> AnimalTypes { get; set; } = null!;
    public float Weight { get; set; }
    public float Length { get; set; }
    public float Height { get; set; }
    public Gender Gender { get; set; }
    public LifeStatus LifeStatus { get; set; }
    
    /// <summary>
    /// DateTime when the animal was chipped
    /// </summary>
    public DateTime ChippingDateTime { get; set; }

    /// <summary>
    /// User who chipped the animal
    /// </summary>
    public virtual User Chipper { get; set; } = null!;
    
    /// <summary>
    /// Location where the animal was chipped
    /// </summary>
    public virtual AnimalLocationPoint ChippingLocation { get; set; } = null!;
    
    /// <summary>
    /// Locations that the animal has visited
    /// </summary>
    public virtual List<VisitedLocation> VisitedLocations { get; set; } = null!;
    
    /// <summary>
    /// DateTime when the animal died (null if it's still alive)
    /// </summary>
    public DateTime? DeathDateTime { get; set; }

    public void AddAnimalType(params AnimalType[] animalType)
    {
        AnimalTypes.AddRange(animalType);
    }

    public void AddVisitedLocation(params VisitedLocation[] visitedLocations)
    {
        VisitedLocations.AddRange(visitedLocations);
    }
}