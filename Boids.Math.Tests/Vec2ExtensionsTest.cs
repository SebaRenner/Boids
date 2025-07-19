namespace Boids.Math.Tests;

public class Vec2ExtensionsTest
{
    [Fact]
    public void Vec2_Sum()
    {
        // Arrange
        var vec1 = new Vec2(2, 2);
        var vec2 = new Vec2(2, 3);
        var vec3 = new Vec2(2, 4);
        var expected = new Vec2(6, 9);

        // Act
        var testee = new List<Vec2> { vec1, vec2, vec3 }.Sum();

        // Assert
        Assert.Equal(expected, testee);
    }

}
