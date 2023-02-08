namespace DripChip.Test.CoreTests;

public class PaginationTest
{
    private IEnumerable<int> _TestingFunction(IEnumerable<int> items, int from = 0, int size = 10) =>
        items.Skip(from).Take(size);
    
    [Fact]
    public void GetAllPaged_Success()
    {
        var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        var expected = new List<int> { 6, 7, 8, 9, 10 };

        var test = _TestingFunction(items, 5, 5);
        Assert.Equal(expected, test);
    }
    
    [Fact]
    public void GetAllPaged_Empty()
    {
        var items = new List<int>();
        var expected = new List<int>();

        var test = _TestingFunction(items, 5, 5);
        Assert.Equal(expected, test);
    }
    
    [Fact]
    public void GetAllPaged_LessElementsSize()
    {
        var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        var expected = new List<int> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        var test = _TestingFunction(items, 5, 20);
        Assert.Equal(expected, test);
    }
    
    [Fact]
    public void GetAllPaged_LessElementsFrom()
    {
        var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        var expected = new List<int>();

        var test = _TestingFunction(items, 25, 20);
        Assert.Equal(expected, test);
    }
}