/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

using DiamondKata.Models;

namespace DiamondKata.Services;

public sealed class InputValidator
{
    private const string EmptyErrorMessage = "Error: Input cannot be empty.";
    private readonly int minimumLevel;
    private readonly int maximumLevel;

    public InputValidator(int minimumLevel = 2, int maximumLevel = 5)
    {
        if (minimumLevel >= maximumLevel)
        {
            throw new ArgumentException("Lower limit must be less than upper limit.");
        }

        this.minimumLevel = minimumLevel;
        this.maximumLevel = maximumLevel;
    }

    public ValidationResult Validate(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return ValidationResult.Failure(EmptyErrorMessage);
        }

        if (!int.TryParse(input, out var level))
        {
            return ValidationResult.Failure($"Error: Please enter a numeric value between {minimumLevel} and {maximumLevel}.");
        }

        if (level < minimumLevel || level > maximumLevel)
        {
            return ValidationResult.Failure($"Error: Value must be between {minimumLevel} and {maximumLevel}.");
        }

        return ValidationResult.Success(level);
    }
}
