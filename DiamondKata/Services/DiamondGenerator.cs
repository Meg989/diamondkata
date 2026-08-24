/*
 * Diamond Kata
 * Version: 1.0.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

namespace DiamondKata.Services;

public sealed class DiamondGenerator
{
    private readonly int minimumLevel;
    private readonly int maximumLevel;

    public DiamondGenerator(int minimumLevel = 2, int maximumLevel = 5)
    {
        if (minimumLevel >= maximumLevel)
        {
            throw new ArgumentException("Lower limit must be less than upper limit.");
        }

        this.minimumLevel = minimumLevel;
        this.maximumLevel = maximumLevel;
    }

    public string Generate(int level)
    {
        if (level < minimumLevel || level > maximumLevel)
        {
            throw new ArgumentOutOfRangeException(nameof(level), $"Value must be between {minimumLevel} and {maximumLevel}.");
        }

        var rows = new List<string>();

        for (var index = 0; index < level; index++)
        {
            rows.Add(BuildRow(level, index));
        }

        for (var index = level - 2; index >= 0; index--)
        {
            rows.Add(BuildRow(level, index));
        }

        return string.Join(Environment.NewLine, rows);
    }

    private static string BuildRow(int level, int index)
    {
        var currentLetter = (char)('A' + index);
        var outerPadding = new string(' ', level - index - 1);

        if (index == 0)
        {
            return $"{outerPadding}{currentLetter}";
        }

        var innerPadding = new string(' ', (index * 2) - 1);
        return $"{outerPadding}{currentLetter}{innerPadding}{currentLetter}";
    }
}
