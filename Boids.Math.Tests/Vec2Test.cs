namespace Boids.Math.Tests;

public class Vec2Test
{
    [Fact]
    public void Vec2_Default_Ctor()
    {
        // Arrange & Act
        var testee = new Vec2();

        // Assert
        Assert.Equal(0, testee.X);
        Assert.Equal(0, testee.Y);
    }

    [Fact]
    public void Vec2_Ctor()
    {
        // Arrange
        var x = 3.66;
        var y = 5.913;

        // Act
        var testee = new Vec2(x, y);

        // Assert
        Assert.Equal(x, testee.X);
        Assert.Equal(y, testee.Y);
    }

    [Fact]
    public void Vec2_Plus()
    {
        // Arrange
        var x1 = 21;
        var y1 = 23;
        var x2 = 4;
        var y2 = 4;
        var xr = x1 + x2;
        var yr = y1 + y2;

        var vec1 = new Vec2(x1, y1);
        var vec2 = new Vec2(x2, y2);

        // Act
        var testee = vec1 + vec2;

        // Assert
        Assert.Equal(xr, testee.X);
        Assert.Equal(yr, testee.Y);
    }

    [Fact]
    public void Vec2_Minus()
    {
        // Arrange
        var x1 = 21;
        var y1 = 23;
        var x2 = 4;
        var y2 = 4;
        var xr = x1 - x2;
        var yr = y1 - y2;

        var vec1 = new Vec2(x1, y1);
        var vec2 = new Vec2(x2, y2);

        // Act
        var testee = vec1 - vec2;

        // Assert
        Assert.Equal(xr, testee.X);
        Assert.Equal(yr, testee.Y);
    }

    [Fact]
    public void Vec2_Multiply_By_Scalar()
    {
        // Arrange
        var x = 21.0;
        var y = 23.0;
        var scalar = 3;
        var xr = x * scalar;
        var yr = y * scalar;
        
        var vec = new Vec2(x, y);

        // Act
        var testee = vec * scalar;

        // Assert
        Assert.Equal(xr, testee.X);
        Assert.Equal(yr, testee.Y);
    }

    [Fact]
    public void Vec2_Divide_By_Scalar()
    {
        // Arrange
        var x = 21.0;
        var y = 23.0;
        var scalar = 3;
        var xr = x / scalar;
        var yr = y / scalar;

        var vec = new Vec2(x, y);

        // Act
        var testee = vec / scalar;

        // Assert
        Assert.Equal(xr, testee.X);
        Assert.Equal(yr, testee.Y);
    }

    [Fact]
    public void Vec2_Distance()
    {
        // Arrange
        var x1 = 21;
        var y1 = 23;
        var x2 = 4;
        var y2 = 4;
        var dx = x1 - x2;
        var dy = y1 - y2;

        var expected = System.Math.Sqrt(dx * dx + dy * dy);

        var vec1 = new Vec2(x1, y1);
        var vec2 = new Vec2(x2, y2);

        // Act
        var testee = vec1.Distance(vec2);

        // Assert
        Assert.Equal(expected, testee);
    }

    [Fact]
    public void Vec2_Length()
    {
        // Arrange
        var x = 5;
        var y = 12;

        var testee = new Vec2(x, y);

        // Act
        var length = testee.Length();

        // Assert
        Assert.Equal(13, length);
    }

    [Fact]
    public void Vec2_LengthSquared()
    {
        // Arrange
        var x = 3;
        var y = 5;

        var testee = new Vec2(x, y);

        // Act
        var length = testee.LengthSquared();

        // Assert
        Assert.Equal(34, length);
    }

    [Fact]
    public void Vec2_Normalized()
    {
        // Arrange
        var x = 3;
        var y = 4;

        var testee = new Vec2(x, y);

        // Act
        var normalized = testee.Normalized();

        // Assert
        Assert.Equal(new Vec2(0.6, 0.8), normalized);
    }

    [Fact]
    public void Vec2_Normalized_LengthZero()
    {
        // Arrange
        var x = 0;
        var y = 0;

        var testee = new Vec2(x, y);

        // Act
        var normalized = testee.Normalized();

        // Assert
        Assert.Equal(new Vec2(0, 0), normalized);
    }
}