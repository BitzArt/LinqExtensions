namespace BitzArt.LinqExtensions.Conditional.Tests;

public class WhereConditionBuilderTests
{
    [Fact]
    public void IsTrue_NoFilter_ShouldNotFilter()
    {
        // Arrange
        var data = Enumerable.Range(1, 10);

        // Act
        var filtered = data.AsQueryable().Where(x => x).IsTrue(x => true).ToList();

        // Assert
        Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], filtered);
    }

    [Fact]
    public void IsTrue_OnlyEven_ShouldFilter()
    {
        // Arrange
        var data = Enumerable.Range(1, 10);

        // Act
        var filtered = data.AsQueryable().Where(x => x).IsTrue(x => x % 2 == 0).ToList();

        // Assert
        Assert.Equal([2, 4, 6, 8, 10], filtered);
    }
}
