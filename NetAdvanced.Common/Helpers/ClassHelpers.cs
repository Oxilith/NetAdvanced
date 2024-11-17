using Microsoft.Extensions.Logging;

namespace NetAdvanced.Common.Helpers;

public static class ClassHelpers
{
    public static T CheckAndReturnIfNotNull<T>(this T? dto, ILogger logger) where T : class?
    {
        logger.LogDebug($"Checking object of type {typeof(T).Name} for null value");
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        return dto;
    }
}