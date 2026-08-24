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
    private const int MinimumLevel = 2;
    private const int MaximumLevel = 5;
    private const string RangeErrorMessage = "Error: Value must be between 2 and 5.";
    private const string NumericErrorMessage = "Error: Please enter a numeric value between 2 and 5.";
    private const string EmptyErrorMessage = "Error: Input cannot be empty.";

    public ValidationResult Validate(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return ValidationResult.Failure(EmptyErrorMessage);
        }

        if (!int.TryParse(input, out var level))
        {
            return ValidationResult.Failure(NumericErrorMessage);
        }

        if (level < MinimumLevel || level > MaximumLevel)
        {
            return ValidationResult.Failure(RangeErrorMessage);
        }

        return ValidationResult.Success(level);
    }
}
