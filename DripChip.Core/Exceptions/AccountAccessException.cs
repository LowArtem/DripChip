namespace DripChip.Core.Exceptions;

/// <summary>
/// Unable to access the source through this account
/// </summary>
public class AccountAccessException : Exception
{
    /// <summary>
    /// Creating the exception
    /// </summary>
    /// <param name="name">name of the entity</param>
    /// <param name="key">conflicted value</param>
    public AccountAccessException()
        : base("Unable to access the source through this account")
    {
    }
}