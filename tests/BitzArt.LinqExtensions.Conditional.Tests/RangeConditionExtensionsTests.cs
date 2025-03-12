namespace BitzArt.LinqExtensions.Conditional.Tests;

public class RangeConditionExtensionsTests
{
    [Fact]
    public void IsIn_NoRange_ShouldNotFilter()
    {
        // Arrange
        var data = Enumerable.Range(1, 10);

        // Act
        var filtered = data.AsQueryable().Where(x => x).IsIn(null).ToList();

        // Assert
        Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], filtered);
    }

    [Theory]
    [InlineData(new int[] {}, 0, 0, true, true, new int[] {})]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 5, true, true, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1, 2, true, true, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, 5, true, true, new int[] { 2, 3, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, 4, false, false, new int[] { 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, 4, true, false, new int[] { 2, 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, 4, false, true, new int[] { 3, 4 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, null, null, true, true, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, null, null, false, false, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, null, 3, true, true, new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3, null, true, true, new int[] { 3, 4, 5 })]
    public void IsIn_Range_ShouldFilter(int[] data, int? lowerBound, int? upperBound, bool includeLowerBound, bool includeUpperBound, int[] expected)
    {
        // Arrange
        var range = new Range<int>(lowerBound, upperBound, includeLowerBound, includeUpperBound);

        // Act
        var filtered = data.AsQueryable().Where(x => x).IsIn(range).ToList();

        // Assert
        Assert.Equal(expected, filtered);
    }
}
