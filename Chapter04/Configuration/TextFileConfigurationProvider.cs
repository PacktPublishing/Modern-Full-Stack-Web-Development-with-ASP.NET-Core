using Microsoft.Extensions.Configuration;

namespace Chapter4
{
    public class TextFileConfigurationProvider : ConfigurationProvider
    {

        public string FilePath { get; }

        public TextFileConfigurationProvider(string filePath)
        {

            FilePath = filePath;

        }

        public override void Load()
        {

            var data = new Dictionary<string, string>();

            if (!File.Exists(FilePath))
            {

                throw new FileNotFoundException($"Configuration file not found: {FilePath}");

            }

            foreach (var line in File.ReadAllLines(FilePath))
            {

                var keyValuePair = line.Split(':');

                if (keyValuePair.Length != 2)

                {

                    throw new FormatException("Line must be in the format 'key:value'");
                }


                data[keyValuePair[0].Trim()] = keyValuePair[1].Trim();

            }

            Data = data;

        }
    }
}
