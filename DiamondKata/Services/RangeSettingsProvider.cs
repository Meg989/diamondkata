/*
 * Diamond Kata
 * Version: 1.1.0
 * Author: Meghal Parikh
 * Last Updated: 2026-08-24
 */

using System.Text.Json;
using DiamondKata.Models;

namespace DiamondKata.Services;

public static class RangeSettingsProvider
{
    private const string SettingsFileName = "appsettings.json";

    public static RangeSettings Load()
    {
        if (!File.Exists(SettingsFileName))
        {
            return new RangeSettings();
        }

        try
        {
            using var stream = File.OpenRead(SettingsFileName);
            using var document = JsonDocument.Parse(stream);

            if (document.RootElement.TryGetProperty("DiamondSettings", out var settingsElement)
                && settingsElement.TryGetProperty("LowerLimit", out var lowerElement)
                && settingsElement.TryGetProperty("UpperLimit", out var upperElement)
                && lowerElement.TryGetInt32(out var lowerLimit)
                && upperElement.TryGetInt32(out var upperLimit)
                && lowerLimit < upperLimit)
            {
                return new RangeSettings
                {
                    LowerLimit = lowerLimit,
                    UpperLimit = upperLimit,
                };
            }
        }
        catch (JsonException)
        {
        }

        return new RangeSettings();
    }
}
