namespace DripChip.Core.Exceptions;

/// <summary>
/// This object already exists and a second one cannot be created
/// </summary>
public class EntityExistsException : Exception
{
    /// <summary>
    /// Creating the exception
    /// </summary>
    /// <param name="name">name of the entity</param>
    /// <param name="key">conflicted value</param>
    public EntityExistsException(string name, object? key)
        : base($"Entity <{name}> ({key ?? "null"}) already exists")
    {
    }
}