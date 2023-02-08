namespace DripChip.Core.Exceptions;

/// <summary>
/// Required environment variable is not set
/// </summary>
public class EnvironmentVariableNotFoundException : Exception
{
    /// <summary>
    /// Creating the exception
    /// </summary>
    public EnvironmentVariableNotFoundException()
        : base("Environment variable not set")
    {
    }
    
    /// <summary>
    /// Creating the exception
    /// </summary>
    /// <param name="variableName">name of the missing variable</param>
    public EnvironmentVariableNotFoundException(string variableName)
        : base($"Environment variable <{variableName}> is not set")
    {
    }
    
    /// <summary>
    /// Creating the exception
    /// </summary>
    /// <param name="variablesNames">names of the missing variables</param>
    public EnvironmentVariableNotFoundException(params string[] variablesNames)
        : base($"Environment variables (one or more): <{string.Join(", ", variablesNames)}> are not set")
    {
    }
}