namespace DripChip.Core.Exceptions;

/// <summary>
/// Unable to access the source through this account
/// </summary>
public class AccountAccessException : Exception
{
    /// <summary>
    /// Creating the exception
    /// </summary>
    public AccountAccessException()
        : base("Unable to access the source through this account")
    {
    }
    
    /// <summary>
    /// Creating the exception
    /// </summary>
    public AccountAccessException(string message)
        : base(message)
    {
    }
}