namespace Nselenide
{
    public class Configuration
    {
        public static string BaseUrl
        {
            get
            {
                return Utils.TryGetEnviormentValue("baseUrl", "https://localhost");
            }
        }

        public static int Timeout
        {
            get
            {
                return int.Parse(Utils.TryGetEnviormentValue("timeout", "30000"));
            }
        }

        public static int Pooling
        {
            get
            {
                return int.Parse(Utils.TryGetEnviormentValue("pooling", "100"));
            }
        }

        public static string Browser
        {
            get
            {
                return Utils.TryGetEnviormentValue("browser", "firefox");
            }
        }

        public static bool Maximize
        {
            get
            {
                return bool.Parse(Utils.TryGetEnviormentValue("maximize", "true"));
            }
        }

        public static bool ScreenShots
        {
            get
            {
                return bool.Parse(Utils.TryGetEnviormentValue("screenshot", "true"));
            }
        }
    }
}
