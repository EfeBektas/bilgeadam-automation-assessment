using Microsoft.Extensions.Configuration;

namespace TestAutomation.Core
{
    public static class ConfigManager
    {
        private static IConfigurationRoot configuration;

        static ConfigManager()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")
                .Build();
        }

        public static string BaseUrl => configuration["baseUrl"];
        public static string Browser => configuration["browser"];

        public static string UserName => configuration["standardUser:username"];
        public static string Password => configuration["standardUser:password"];

        public static int ExplicitWait => int.Parse(configuration["timeouts:explicit"]);
        public static int ImplicitWait => int.Parse(configuration["timeouts:implicit"]);
    }
}
