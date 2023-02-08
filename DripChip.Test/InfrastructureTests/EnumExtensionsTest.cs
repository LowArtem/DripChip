using DripChip.Core.Enums;
using DripChip.Core.Extensions;

namespace DripChip.Test.InfrastructureTests;

public class EnumExtensionsTest
{
    [Fact]
    public void ParseEnumResulted_Success()
    {
        var genderExpected = Gender.FEMALE;
        var test = "FEMALE";

        var result = EnumExtensions.ParseEnumResulted<Gender>(test);
        
        Assert.True(result.IsSuccess);
        Assert.Equal(genderExpected, result.Value);
    }
    
    [Fact]
    public void ParseEnumResulted_Fail_Wrong()
    {
        var test = "unacceptable text";

        var result = EnumExtensions.ParseEnumResulted<Gender>(test);
        
        Assert.False(result.IsSuccess);
        Assert.True(result.ExceptionIs<ArgumentException>());
    }
    
    [Fact]
    public void ParseEnumResulted_Fail_Null()
    {
        string test = null;

        var result = EnumExtensions.ParseEnumResulted<Gender>(test);
        
        Assert.False(result.IsSuccess);
        Assert.True(result.ExceptionIs<ArgumentNullException>());
    }
}