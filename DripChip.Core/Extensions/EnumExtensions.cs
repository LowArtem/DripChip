namespace DripChip.Core.Extensions;

public static class EnumExtensions
{
    public static Result<T> ParseEnumResulted<T>(string value)
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        catch (Exception e)
        {
            return e;
        }
    }
    
    public static T ParseEnumThrowable<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}