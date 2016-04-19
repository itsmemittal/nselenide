using System;

namespace Nselenide
{
    public static class Utils
    {
        public static string TryGetEnviormentValue(string variable,string defultValue)
        {
            var envValue = Environment.GetEnvironmentVariable(variable);
            if (!string.IsNullOrEmpty(envValue))
            {
                return envValue;
            }
            Environment.SetEnvironmentVariable(variable,defultValue);
            return defultValue;
        }
    }
}
