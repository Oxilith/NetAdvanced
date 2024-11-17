using System.Diagnostics;

namespace NetAdvanced.WebApi.Helpers;

internal static class EnvironmentHelpers
{
    private static bool _isDebug = false;

    public static bool IsDebug
    {
        get
        {
            SetIsDebug();
            return _isDebug;
        }
    }

    [Conditional("DEBUG")]
    private static void SetIsDebug()
    {
        _isDebug = true;
    }
}