namespace DripChip.Core.Entities.Abstract;

/// <summary>
/// Base application and at the same time database entity
/// </summary>
/// <typeparam name="T">database key type</typeparam>
public abstract class BaseEntity<T>
{
    /// <summary>
    /// Unique entity identifier
    /// </summary>
    public virtual T Id { get; protected set; }
}