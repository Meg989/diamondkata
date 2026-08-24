/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

using System.Diagnostics.CodeAnalysis;
using DiamondKata.Models;
using DiamondKata.Services;

namespace DiamondKata;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main()
    {
        var rangeSettings = RangeSettingsProvider.Load();
        var validator = new InputValidator(rangeSettings.LowerLimit, rangeSettings.UpperLimit);
        var generator = new DiamondGenerator(rangeSettings.LowerLimit, rangeSettings.UpperLimit);

        while (true)
        {
            Console.Write($"Enter a number between {rangeSettings.LowerLimit} and {rangeSettings.UpperLimit}: ");
            var input = Console.ReadLine();

            var validationResult = validator.Validate(input);

            if (!validationResult.IsValid)
            {
                Console.WriteLine(validationResult.ErrorMessage);
                Console.WriteLine($"Please try again with a value between {rangeSettings.LowerLimit} and {rangeSettings.UpperLimit}.");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine(generator.Generate(validationResult.Level));
            break;
        }

        Console.WriteLine();
        Console.Write("Press any key to exit...");
        Console.ReadKey(true);
    }
}
