/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

namespace DiamondKata.Models;

public sealed class ValidationResult
{
    private ValidationResult(bool isValid, int level, string? errorMessage)
    {
        IsValid = isValid;
        Level = level;
        ErrorMessage = errorMessage;
    }

    public bool IsValid { get; }

    public int Level { get; }

    public string? ErrorMessage { get; }

    public static ValidationResult Success(int level) => new(true, level, null);

    public static ValidationResult Failure(string errorMessage) => new(false, 0, errorMessage);
}
