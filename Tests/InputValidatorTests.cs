/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

using DiamondKata.Services;

namespace Tests;

public sealed class InputValidatorTests
{
    private readonly InputValidator inputValidator = new();

    [Theory]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    public void Validate_ValidInput_ReturnsSuccess(string input, int expectedLevel)
    {
        var result = inputValidator.Validate(input);

        Assert.True(result.IsValid);
        Assert.Equal(expectedLevel, result.Level);
        Assert.Null(result.ErrorMessage);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("0")]
    [InlineData("6")]
    [InlineData("10")]
    public void Validate_OutOfRangeInput_ReturnsRangeError(string input)
    {
        var result = inputValidator.Validate(input);

        Assert.False(result.IsValid);
        Assert.Equal("Error: Value must be between 2 and 5.", result.ErrorMessage);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("abc")]
    [InlineData("#")]
    [InlineData("%")]
    [InlineData("@")]
    public void Validate_NonNumericInput_ReturnsNumericError(string input)
    {
        var result = inputValidator.Validate(input);

        Assert.False(result.IsValid);
        Assert.Equal("Error: Please enter a numeric value between 2 and 5.", result.ErrorMessage);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Validate_EmptyInput_ReturnsEmptyError(string input)
    {
        var result = inputValidator.Validate(input);

        Assert.False(result.IsValid);
        Assert.Equal("Error: Input cannot be empty.", result.ErrorMessage);
    }

    [Fact]
    public void Validate_CustomRange_ValidInput_ReturnsSuccess()
    {
        var validator = new InputValidator(3, 7);

        var result = validator.Validate("6");

        Assert.True(result.IsValid);
        Assert.Equal(6, result.Level);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void Validate_CustomRange_OutOfRangeInput_ReturnsRangeError()
    {
        var validator = new InputValidator(3, 7);

        var result = validator.Validate("2");

        Assert.False(result.IsValid);
        Assert.Equal("Error: Value must be between 3 and 7.", result.ErrorMessage);
    }
}
