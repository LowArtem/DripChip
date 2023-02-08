namespace DripChip.Core.Extensions;

/// <summary>
/// Result of any operation (can be used instead of throwing an exception)
/// </summary>
/// <typeparam name="T">type of successful result</typeparam>
public struct Result<T>
{
    /// <summary>Successful value</summary>
    public T? Value { get; }
    
    /// <summary>Failure exception</summary>
    public Exception? Exception { get; }

    /// <summary>Is operation successful</summary>
    [System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, nameof(Value))]
    [System.Diagnostics.CodeAnalysis.MemberNotNullWhen(false, nameof(Exception))]
    public bool IsSuccess { get; }

    /// <summary>
    /// Create a successful object
    /// </summary>
    /// <param name="value">successfully received value</param>
    public Result(T value)
    {
        IsSuccess = true;
        Exception = null;
        Value = value;
    }

    /// <summary>
    /// Create a failed object
    /// </summary>
    /// <param name="exception">failure describing exception</param>
    /// <exception cref="ArgumentNullException">if exception is null</exception>
    public Result(Exception exception)
    {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        IsSuccess = false;
        Value = default;
    }

    public static implicit operator Result<T>(T value)
        => new(value);

    public static implicit operator Result<T>(Exception exception)
        => new(exception);
    
    /// <summary>
    /// Exception type comparing
    /// </summary>
    /// <typeparam name="TException">type to compare</typeparam>
    /// <returns>comparing result</returns>
    public bool ExceptionIs<TException>()
        where TException : Exception
        => Exception is TException;

    /// <summary>
    /// Result conversion
    /// </summary>
    /// <param name="converter">conversion function</param>
    /// <typeparam name="TEnd">new type</typeparam>
    /// <returns>new result of type <typeparamref name="TEnd"/></returns>
    public Result<TEnd> ConvertToAnotherResult<TEnd>(Func<T, TEnd> converter)
        => IsSuccess
            ? new Result<TEnd>(converter(Value))
            : new Result<TEnd>(Exception);

    /// <summary>
    /// Conversion into the empty result
    /// </summary>
    /// <remarks>If there is a value it will be lost</remarks>
    /// <returns>empty result</returns>
    public Result ConvertToEmptyResult()
        => IsSuccess
            ? new Result(true)
            : new Result(Exception);

    public void Deconstruct(out bool success, out T? value)
        => (success, value) = (IsSuccess, Value);

    public void Deconstruct(out bool success, out T? value, out Exception? exception)
        => (success, value, exception) = (IsSuccess, Value, Exception);

    public static implicit operator bool(Result<T> result)
        => result.IsSuccess;

    public static implicit operator Task<Result<T>>(Result<T> result)
        => result.AsTask;

    /// <summary>Async result</summary>
    public Task<Result<T>> AsTask => Task.FromResult(this);
}

/// <summary>
/// Result of any operation (can be used instead of throwing an exception)
/// </summary>
public struct Result
{
    /// <summary>Failure exception</summary>
    public Exception? Exception { get; }
    
    /// <summary>Is operation successful</summary>
    [System.Diagnostics.CodeAnalysis.MemberNotNullWhen(false, nameof(Exception))]
    public bool IsSuccess { get; }

    /// <summary>
    /// Create a result
    /// </summary>
    /// <param name="success">is operation successful</param>
    public Result(bool success)
    {
        IsSuccess = success;
        Exception = null;
    }

    /// <summary>
    /// Create a failed object
    /// </summary>
    /// <param name="exception">failure describing exception</param>
    /// <exception cref="ArgumentNullException">if exception is null</exception>
    public Result(Exception exception)
    {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        IsSuccess = false;
    }

    /// <summary>
    /// Exception type comparing
    /// </summary>
    /// <typeparam name="TException">type to compare</typeparam>
    /// <returns>comparing result</returns>
    public bool ExceptionIs<TException>()
        where TException : Exception
        => Exception is TException;

    /// <summary>
    /// Create a successful object
    /// </summary>
    /// <returns>successful result</returns>
    public static Result Success()
        => new(true);
    
    /// <summary>
    /// Create a successful object
    /// </summary>
    /// <param name="value">successfully received value</param>
    /// <typeparam name="T">value type</typeparam>
    /// <returns>successful result</returns>
    public static Result<T> Success<T>(T value)
        => new(value);

    /// <summary>
    /// Create a failed object
    /// </summary>
    /// <param name="exception">failure describing exception</param>
    /// <returns>failed result</returns>
    public static Result Fail(Exception exception)
        => new(exception);

    /// <summary>
    /// Create a failed object
    /// </summary>
    /// <param name="exception">failure describing exception</param>
    /// <typeparam name="T">type of missing value</typeparam>
    /// <returns>failed result</returns>
    public static Result<T> Fail<T>(Exception exception)
        => new(exception);

    public static implicit operator Result(Exception exception)
        => new(exception);

    public static implicit operator bool(Result result)
        => result.IsSuccess;

    public static implicit operator Task<Result>(Result result)
        => result.AsTask;

    public void Deconstruct(out bool success, out Exception? exception)
        => (success, exception) = (IsSuccess, Exception);

    /// <summary>Async result</summary>
    public Task<Result> AsTask => Task.FromResult(this);
}