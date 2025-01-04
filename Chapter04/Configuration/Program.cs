using Microsoft.Extensions.Configuration;

namespace Chapter4
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region Environment Variables
            var configBuilder = new ConfigurationBuilder()

                .AddJsonFile("mysettings.json", optional: true, reloadOnChange: true)

                .AddEnvironmentVariables();

            IConfiguration config = configBuilder.Build();

            Console.WriteLine($"Custom config: {config["ExampleSetting"]}");

            Console.WriteLine($"ConnectionString: {config["ConnectionStrings:Default"]}");

            #endregion

            #region Path
            var builder = new ConfigurationBuilder()

                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            Console.WriteLine($"PATH: {configuration["PATH"]}");

            #endregion

            #region CommandLine

            string[] arguments = { "--ConnectionStrings:Default=MyConnectionString" };
            
            builder = new ConfigurationBuilder()

                .AddCommandLine(arguments);

            config = builder.Build();

            Console.WriteLine($"ConnectionString: {config["ConnectionStrings:Default"]}");
            #endregion


            #region XML configuration
            builder = new ConfigurationBuilder()

               .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);

            config = builder.Build();

            Console.WriteLine($"LogFilePath: {config["LogSettings: LogFilePath"]}");

            #endregion

            #region Secrets Manager

            builder = new ConfigurationBuilder()
                    .AddUserSecrets<Program>();

            config = builder.Build();

            Console.WriteLine($"APIKey: {config["APIKey"]}");

            #endregion

            #region Memory Provider
            var dict = new Dictionary<string, string>()
            {

                { "RunTimeSettng","Value"}

            };

            builder = new ConfigurationBuilder()

                .AddInMemoryCollection(dict);

            config = builder.Build();

            Console.WriteLine($"RunTimeSettng: {config["RunTimeSettng"]}");
            #endregion

            #region Text File Configuration Source

            builder = new ConfigurationBuilder()

               .Add(new TextFileConfigurationSource() { FilePath = "config.txt" });

            config = builder.Build();

            Console.WriteLine($"Example setting: {config["ExampleSetting"]}");
            #endregion

        }
    }
}
