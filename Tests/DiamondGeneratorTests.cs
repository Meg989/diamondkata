/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

using DiamondKata.Services;

namespace Tests;

public sealed class DiamondGeneratorTests
{
    private readonly DiamondGenerator diamondGenerator = new();

    [Fact]
    public void Generate_Level2_ReturnsExpectedDiamond()
    {
        var expected = string.Join(Environment.NewLine, " A", "B B", " A");

        var result = diamondGenerator.Generate(2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Generate_Level3_ReturnsExpectedDiamond()
    {
        var expected = string.Join(Environment.NewLine, "  A", " B B", "C   C", " B B", "  A");

        var result = diamondGenerator.Generate(3);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Generate_Level4_ReturnsExpectedDiamond()
    {
        var expected = string.Join(Environment.NewLine, "   A", "  B B", " C   C", "D     D", " C   C", "  B B", "   A");

        var result = diamondGenerator.Generate(4);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Generate_Level5_ReturnsExpectedDiamond()
    {
        var expected = string.Join(Environment.NewLine, "    A", "   B B", "  C   C", " D     D", "E       E", " D     D", "  C   C", "   B B", "    A");

        var result = diamondGenerator.Generate(5);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(6)]
    public void Generate_InvalidLevel_ThrowsArgumentOutOfRangeException(int level)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => diamondGenerator.Generate(level));
    }
}
