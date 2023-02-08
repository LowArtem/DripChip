namespace DripChip.Core.Exceptions;

/// <summary>
/// Required object not found
/// </summary>
public class EntityNotFoundException : Exception
{
    /// <summary>
    /// Creating the exception
    /// </summary>
    /// <param name="name">name of the entity</param>
    /// <param name="key">missing value</param>
    public EntityNotFoundException(string name, object? key)
        : base($"Entity <{name}> ({key ?? "null"}) not found")
    {
    }
}