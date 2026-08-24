/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

using System.Diagnostics.CodeAnalysis;
using DiamondKata.Services;

namespace DiamondKata;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main()
    {
        Console.Write("Enter a number between 2 and 5: ");
        var input = Console.ReadLine();

        var validator = new InputValidator();
        var validationResult = validator.Validate(input);

        if (!validationResult.IsValid)
        {
            Console.WriteLine(validationResult.ErrorMessage);
            return;
        }

        var generator = new DiamondGenerator();
        Console.WriteLine(generator.Generate(validationResult.Level));
    }
}
