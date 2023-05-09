namespace METROAssignment.API.Configuration
{
    public static class ConfigurationHelper
    {
        public static IConfigurationBuilder GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return configurationBuilder;
        }
    }
}
